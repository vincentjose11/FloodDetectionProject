using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloodDetectionApp.Services;

class Program
{
    static void Main(string[] args)
    {
        string rainfallFolder = @"C:\RainfallData";
        string deviceFile = @"C:\devices.csv";

        var csvService = new CsvParserService();
        var rainfallService = new RainfallService();

        var devices = csvService.ReadDevices(deviceFile);
        var readings = csvService.ReadRainfall(rainfallFolder);

        rainfallService.Process(readings, devices);

        Console.ReadLine();
    }
}