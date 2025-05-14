using System;
using FluentAssertions;
using HolidaySearch.Models;


namespace HolidaySearch.Tests
{
    public class SearchHolidayTests
    {
        SearchHolidays _searchHolidays;

        [SetUp]
        public void Setup()
        {
            _searchHolidays = new SearchHolidays();
        }

        [Test]
        public void Given_SearchHolidays_Is_Called_With_No_Data_An_Error_Should_Return()
        {
            // Arrange
            HolidayPackage searchCriteria = null;

            // Act
            var _searchResults = () => _searchHolidays.SearchBestValueHolidays(searchCriteria);
            // Assert
            _searchResults.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Given_SearchHolidays_Is_Called_With_Valid_Data_No_Error_Should_Be_Thrown()
        {
            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage();

            // Act
            var _searchResults = () => _searchHolidays.SearchBestValueHolidays(searchCriteria);
            // Assert
            _searchResults.Should().NotThrow<ArgumentNullException>();
        }

    } 
}