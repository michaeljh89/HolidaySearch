using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HolidaySearch.Models;

namespace HolidaySearch.Repository
{
    internal class HotelRepository : IHotelRepository
    {
        internal readonly IReadOnlyList<Hotel> RawData;
        
        public HotelRepository(string rawDataPath)
        {
            RawData = ReadHotelsFromJson(rawDataPath);
        }

        public async Task<IList<Hotel>> SearchHotelsAsync(DateTime departureDate, int duration, string travellingTo)
        {
            var result = RawData;

            var filteredResults = result.Where(x => x.arrival_date == departureDate && x.nights == duration
            && x.local_airports.Contains(travellingTo))
                  .OrderBy(f => f.price_per_night)
            .ToList();

            return await Task.FromResult(new List<Hotel>(filteredResults));
        }

        private static List<Hotel> ReadHotelsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"JSON file not found at path: {filePath}");
            var json = File.ReadAllText(filePath);
            var hotels = JsonSerializer.Deserialize<List<Hotel>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return hotels ?? new List<Hotel>();
        }

        
    }
}
