using System;
using System.Collections.Generic;
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
            List<HolidayPackageResult> holidayPackageResults = new List<HolidayPackageResult>();
            return holidayPackageResults;
        }
    }
}
