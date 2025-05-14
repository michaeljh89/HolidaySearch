using System.IO;
using FluentAssertions;
using HolidaySearch.Repository;

namespace HolidaySearch.Tests.Repository
{
    [TestFixture]
    public class FlightRepositoryTests
    {        
        private string _WrongFilePath = "..//..//..//MockJsonData//NotHere.json";        

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

    }
}