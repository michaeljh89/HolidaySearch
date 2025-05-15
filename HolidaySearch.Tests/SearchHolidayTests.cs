using System;
using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using HolidaySearch.Models;
using HolidaySearch.Repository;


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

        [Test]
        public void Given_SearchHolidays_Is_Called_With_Valid_Data()
        {

            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage()
            {
                DepartingFrom = "MAN",
                TravelingTo = "PMI",
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = 14
            };
            
            _searchHolidays = new SearchHolidays();

            //Act
            List<HolidayPackageResult> results = _searchHolidays.SearchBestValueHolidays(searchCriteria);

            //Assert
            results.Should().NotBeNull();
        }

        [Test]
        public void Given_SearchHolidays_Is_Called_With_InValid_Data()
        {

            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage()
            {
                DepartingFrom = "34efefef",
                TravelingTo = "",
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = -1
            };

            _searchHolidays = new SearchHolidays();

            //Act
            var results = () => _searchHolidays.SearchBestValueHolidays(searchCriteria);

            //Assert
            results.Should().Throw<InvalidDataException>();
        }

    } 
}