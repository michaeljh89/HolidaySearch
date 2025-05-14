using System.IO;
using FluentAssertions;
using FluentAssertions.Extensions;
using HolidaySearch.Repository;

namespace HolidayFinder.Tests.Repository
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
    }
}