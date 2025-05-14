using System;

namespace HolidaySearch.Models
{
    public class Flight
    {
        public int id { get; set; }
        public string airline { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public decimal price { get; set; }
        public DateTime departure_date { get; set; }
    }
}