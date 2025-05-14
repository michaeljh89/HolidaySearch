using HolidaySearch.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HolidaySearch.Repository
{
    internal class FlightRepository : IFlightRepository
    {
        internal readonly IList<Flight> RawData;

        public FlightRepository(string rawDataPath)
        {
            RawData = ReadFlightsFromJson(rawDataPath);
        }

        private static List<Flight> ReadFlightsFromJson(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"JSON file not found at path: {filePath}");

            var json = File.ReadAllText(filePath);
            var flights = JsonSerializer.Deserialize<List<Flight>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return flights ?? new List<Flight>();
        }
    }
}