using System.IO;
using FluentAssertions;
using FluentAssertions.Extensions;
using HolidaySearch.Repository;

namespace HolidaySearch.Tests.Repository
{
    [TestFixture]
    public class FlightRepositoryTests
    {
        private string _WrongFilePath = "..//..//..//MockJsonData//NotHere.json";
        private string _MockDataFilePath = "..//..//..//MockJsonData//FlightData.json";

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Given_A_File_With_InvalidData_Then_AnError_Should_Be_Thrown()
        {
            // Arrange
            var flightRepo = () => new FlightRepository(_WrongFilePath);
            // Assert
            flightRepo.Should().Throw<FileNotFoundException>();
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_Returned_RawData_Should_Be_Populated_With_12_Records()
        {
            // Arrange
            var flightRepo = new FlightRepository(_MockDataFilePath);
            // Act
            var flightData = flightRepo.RawData;
            // Assert
            flightData.Should().NotBeNullOrEmpty();
            flightData.Should().HaveCount(12);
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_RawData_Should_Be_Populated_With_Correct_Data()
        {
            // Arrange
            var flightRepo = new FlightRepository(_MockDataFilePath);
            // Act
            var flightData = flightRepo.RawData;
            // Assert
            flightData.Should().NotBeNullOrEmpty();
            flightData[0].Price.Should().Be(470);
        }

        [Test]
        public void Given_A_File_With_ValidData_Then_Each_Record_Should_Have_Required_Fields()
        {
            // Arrange
            var flightRepo = new FlightRepository(_MockDataFilePath);
            var mockTodaysDate = 1.January(2022);
            // Act
            var flightData = flightRepo.RawData;
            // Assert

            foreach (var flight in flightData)
            {
                flight.Should().NotBeNull();
                flight.Departure_date.Should().BeAfter(mockTodaysDate);
                flight.From.Should().NotBeNullOrEmpty();
                flight.To.Should().NotBeNullOrEmpty();
                flight.Price.Should().BeGreaterThanOrEqualTo(0);
            }

        }
    }
}