using System;
using System.Collections.Generic;
using System.Linq;
namespace FloodDetectionApp.Services
{
    public class RainfallService
    {
        public void Process(List<RainfallReading> readings, List<Device> devices)
        {
            var currentTime = readings.Max(r => r.Timestamp);

            var last4HoursReading = readings
                .Where(r => r.Timestamp >= currentTime.AddHours(-4))
                .ToList();

            var deviceGroups = last4HoursReading.GroupBy(r => r.DeviceId);

            foreach (var deviceGroup in deviceGroups)
            {
                var device = devices.FirstOrDefault(d => d.DeviceId == deviceGroup.Key);

                var orderByTime = deviceGroup.OrderBy(r => r.Timestamp).ToList();

                double avg = orderByTime.Average(r => r.Rainfall);

                string trend = GetTrend(orderByTime);
                string status = GetStatus(avg, orderByTime);

                Console.WriteLine($"Device ID   : {deviceGroup.Key}");
                Console.WriteLine($"Name        : {device?.DeviceName}");
                Console.WriteLine($"Location    : {device?.Location}");
                Console.WriteLine($"Avg Rainfall: {avg}");
                Console.WriteLine($"Status      : {status}");
                Console.WriteLine($"Trend       : {trend}");
                Console.WriteLine("----------------------------------");
            }
        }

        public string GetTrend(List<RainfallReading> readings)
        {
            if (readings.Count < 2) return "Stable";

            var first = readings.First().Rainfall;
            var last = readings.Last().Rainfall;

            if (last > first) return "Increasing";
            if (last < first) return "Decreasing";

            return "Stable";
        }

        public string GetStatus(double avg, List<RainfallReading> readings)
        {
            try
            {
                if (readings.Any(r => r.Rainfall > 30) || avg >= 15)
                    return "Red";

                else if (avg < 10)
                    return "Green";

                else if (avg < 15)
                    return "Amber";

                else
                    return "Invalid Data";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating status: {ex.Message}");
                return "Error";
            }
        }
    }
}