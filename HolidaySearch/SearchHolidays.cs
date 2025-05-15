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
                || searchCriteria.Duration <= 0 )
            {
                throw new InvalidDataException("Invalid search criteria");
            }

            var hotelResults = _hotelsRepository.SearchHotelsAsync(searchCriteria.DepartureDate, searchCriteria.Duration, searchCriteria.TravelingTo);
            var flightResults = _flightsRepository.SearchFlightsAsync(searchCriteria.DepartingFrom, searchCriteria.TravelingTo, searchCriteria.DepartureDate);
            
            var hotels = hotelResults.Result;
            var flights = flightResults.Result;

            List<HolidayPackageResult> holidayPackageResults = new List<HolidayPackageResult>();

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

            holidayPackageResults = (List<HolidayPackageResult>)holidayPackageResults.OrderBy(o => o.TotalPrice).ToList();

            return holidayPackageResults;
        }
    }
}
