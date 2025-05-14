using System;

namespace HolidaySearch.Models
{
    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Price { get; set; }
        public DateTime Departure_date { get; set; }
    }
}