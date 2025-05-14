using System.IO;
using FluentAssertions;
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

    }
}