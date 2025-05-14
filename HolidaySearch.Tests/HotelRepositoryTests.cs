using System.IO;
using FluentAssertions;
using FluentAssertions.Extensions;
using HolidaySearch.Repository;

namespace HolidaySearch.Tests.Repository
{
    [TestFixture]
    public class HotelRepositoryTests
    {
        private string _MockDataFilePath = "..//..//..//MockJsonData//HotelData.json";
        private string _WrongFilePath = "..//..//..//MockJsonData//NotHere.json";        

        [SetUp]
        public void SetUp()
        {            
        }

        [Test]
        public void Given_A_File_With_InvalidData_Then_AnError_Should_Be_Thrown()
        {
            // Arrange
            var hotelRepo = () => new HotelRepository(_WrongFilePath);
            // Assert
            hotelRepo.Should().Throw<FileNotFoundException>();
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_RawData_Should_Be_Populated_With_13_Records()
        {
            // Arrange
            var hotelRepo = new HotelRepository(_MockDataFilePath);
            // Act
            var hotelData = hotelRepo.RawData;
            // Assert
            hotelData.Should().NotBeNullOrEmpty();
            hotelData.Should().HaveCount(13);
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_RawData_Should_Be_Populated_With_Correct_Data()
        {
            // Arrange
            var hotelRepo = new HotelRepository(_MockDataFilePath);
            // Act
            var hotelData = hotelRepo.RawData;
            // Assert
            hotelData.Should().NotBeNullOrEmpty();
            hotelData[0].price_per_night.Should().Be(100);
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_Each_Record_Should_Have_Required_Fields()
        {
            // Arrange
            var hotelRepo = new HotelRepository(_MockDataFilePath);
            var mockTodaysDate = 1.January(2022);
            // Act
            var flightData = hotelRepo.RawData;
            // Assert

            foreach (var flight in flightData)
            {
                flight.Should().NotBeNull();
                flight.arrival_date.Should().BeAfter(mockTodaysDate);
                flight.name.Should().NotBeNullOrEmpty();
                flight.nights.Should().BeGreaterThanOrEqualTo(0);
                flight.price_per_night.Should().BeGreaterThanOrEqualTo(0);
            }
        }

        
    }
}