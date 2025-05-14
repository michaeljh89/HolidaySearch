namespace HolidaySearch
{
    internal class SearchHolidays
    {
        public SearchHolidays()
        {

        }

        public void SearchBestValueHolidays(holidayPackage searchCriteria)
        {
            if (searchCriteria == null)
            {
                throw new ArgumentNullException(nameof(searchCriteria), "Search criteria cannot be null");
            }
        }
    }
}
