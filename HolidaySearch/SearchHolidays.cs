using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HolidaySearch.Models;

namespace HolidaySearch
{
    internal class SearchHolidays
    {
        public SearchHolidays()
        {

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

            List<HolidayPackageResult> holidayPackageResults = new List<HolidayPackageResult>();
            return holidayPackageResults;
        }
    }
}
