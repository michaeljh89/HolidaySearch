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
