using HolidaySearch.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace HolidaySearch.Repository
{
    internal interface IHotelRepository
    {
        Task<IList<Hotel>> SearchHotelsAsync(DateTime departureDate, int duration, string travellingTo);
    }
}