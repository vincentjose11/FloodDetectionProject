using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class CsvParserService
{
    public List<Device> ReadDevices(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return csv.GetRecords<Device>().ToList();
        }
    }

    public List<RainfallReading> ReadRainfall(string folderPath)
    {
        var readings = new List<RainfallReading>();

        var files = Directory.GetFiles(folderPath, "*.csv");

        foreach (var file in files)
        {
            using (var reader = new StreamReader(file))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<RainfallReading>();
                readings.AddRange(records);
            }
        }

        return readings;
    }
}