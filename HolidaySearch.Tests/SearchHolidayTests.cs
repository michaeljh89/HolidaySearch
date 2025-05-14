using System;
using FluentAssertions;
using FluentAssertions.Execution;


namespace HolidaySearch.Tests
{
    public class SearchHolidayTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]        
        public void Given_SearchHolidays_Is_Called_With_No_Data_An_Error_Should_Return()
        {
            // Arrange
            holidayPackage searchCriteria = null;
            var _searchHolidays = new SearchHolidays();
            // Act
            var _searchResults = () => _searchHolidays.SearchBestValueHolidays(searchCriteria);
            // Assert
            _searchResults.Should().Throw<ArgumentNullException>();
        }
    }
}