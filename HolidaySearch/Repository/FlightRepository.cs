using HolidaySearch.Models;
using System.Collections.Generic;

namespace HolidaySearch.Repository
{
    internal class FlightRepository : IFlightRepository
    {
        internal readonly IList<Flight> RawData;

        public FlightRepository(string rawDataPath)
        {
            
        }
    }
}