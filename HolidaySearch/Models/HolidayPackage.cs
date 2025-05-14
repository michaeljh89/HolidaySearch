using System;

namespace HolidaySearch.Models
{
    public class HolidayPackage
    {
        public string DepartingFrom { get; set; }
        public string TravelingTo { get; set; }
        public DateTime DepartureDate { get; set; }
        public int Duration { get; set; }
    }
}