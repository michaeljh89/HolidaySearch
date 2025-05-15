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
        private const string HotelRawDataPath = "..//..//..//MockJsonData//HotelData.json";
        private const string FlightRawDataPath = "..//..//..//MockJsonData//FlightData.json";

        SearchHolidays _searchHolidays;

        [SetUp]
        public void Setup()
        {
            var _searchHolidays = new SearchHolidays(new HotelRepository(HotelRawDataPath), new FlightRepository(FlightRawDataPath));
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
        public void Given_SearchHolidays_Is_Called_With_Valid_Data_Then_A_Valid_HolidayPackageResult_Should_Return()
        {

            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage()
            {
                DepartingFrom = "MAN",
                TravelingTo = "PMI",
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = 14
            };

            var _searchHolidays = new SearchHolidays(new HotelRepository(HotelRawDataPath), new FlightRepository(FlightRawDataPath));

            //Act
            List<HolidayPackageResult> results = _searchHolidays.SearchBestValueHolidays(searchCriteria);

            //Assert
            results.Should().NotBeNull();
        }

        [Test]
        public void Given_SearchHolidays_Is_Called_With_InValid_Data_Then_Error_Should_be_thrown()
        {

            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage()
            {
                DepartingFrom = "34efefef",
                TravelingTo = "",
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = -1
            };

            var _searchHolidays = new SearchHolidays(new HotelRepository(HotelRawDataPath), new FlightRepository(FlightRawDataPath));

            //Act
            var results = () => _searchHolidays.SearchBestValueHolidays(searchCriteria);

            //Assert
            results.Should().Throw<InvalidDataException>();
        }

        [Test]
        public void Given_SearchHolidays_Is_Called_With_Valid_Data_The_Best_Value_HolidayResult_Should_Return()
        {

            // Arrange
            HolidayPackage searchCriteria = new HolidayPackage()
            {
                DepartingFrom = "MAN",
                TravelingTo = "PMI",
                DepartureDate = new DateTime(2023, 06, 15),
                Duration = 14
            };

            var _searchHolidays = new SearchHolidays(new HotelRepository(HotelRawDataPath), new FlightRepository(FlightRawDataPath));

            //Act
            List<HolidayPackageResult> results = _searchHolidays.SearchBestValueHolidays(searchCriteria);

            //Assert
            results.Should().NotBeNull();
            results.Should().HaveCount(4);
        }

    } 
}