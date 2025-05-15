using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HolidaySearch.Models;
using HolidaySearch.Repository;

namespace HolidaySearch
{
    internal class SearchHolidays
    {
        private readonly IHotelRepository _hotelsRepository;
        private readonly IFlightRepository _flightsRepository;

        public SearchHolidays(IHotelRepository hotelsRepository, IFlightRepository flightsRepository)
        {
            _hotelsRepository = hotelsRepository;
            _flightsRepository = flightsRepository;
        }

        public List<HolidayPackageResult> SearchBestValueHolidays(HolidayPackage searchCriteria)
        {
            if (searchCriteria == null)
            {
                throw new ArgumentNullException(nameof(searchCriteria), "Search criteria cannot be null");
            }

            if (searchCriteria.DepartingFrom.Length != 3 || searchCriteria.TravelingTo.Length != 3
                || searchCriteria.Duration <= 0)
            {
                throw new InvalidDataException("Invalid search criteria");
            }

            IList<Hotel> hotels;
            IList<Flight> flights;
            GetFlightAndHotelData(searchCriteria, out hotels, out flights);

            List<HolidayPackageResult> holidayPackageResults = new List<HolidayPackageResult>();
            GenerateHolidayPackageResults(hotels, flights, holidayPackageResults);

            holidayPackageResults = holidayPackageResults.OrderBy(o => o.TotalPrice).ToList();

            return holidayPackageResults;
        }

        private static void GenerateHolidayPackageResults(IList<Hotel> hotels, IList<Flight> flights, List<HolidayPackageResult> holidayPackageResults)
        {
            foreach (var hotel in hotels)
            {
                foreach (var flight in flights)
                {
                    if (hotel.local_airports.Contains(flight.To))
                        holidayPackageResults.Add(new HolidayPackageResult
                        {
                            Flight = flight,
                            Hotel = hotel,
                            TotalPrice = flight.Price + (hotel.price_per_night * hotel.nights)
                        });
                }
            }
        }

        private void GetFlightAndHotelData(HolidayPackage searchCriteria, out IList<Hotel> hotels, out IList<Flight> flights)
        {
            var hotelResults = _hotelsRepository.SearchHotelsAsync(searchCriteria.DepartureDate, searchCriteria.Duration, searchCriteria.TravelingTo);
            var flightResults = _flightsRepository.SearchFlightsAsync(searchCriteria.DepartingFrom, searchCriteria.TravelingTo, searchCriteria.DepartureDate);

            hotels = hotelResults.Result;
            flights = flightResults.Result;
        }
    }
}
