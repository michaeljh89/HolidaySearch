using HolidaySearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HolidaySearch.Repository
{
    internal interface IFlightRepository
    {
        Task<IList<Flight>> SearchFlightsAsync(string departingFrom, string travellingTo, DateTime departureDate);
    }
}