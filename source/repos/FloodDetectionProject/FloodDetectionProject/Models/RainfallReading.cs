using CsvHelper.Configuration.Attributes;
using System;

public class RainfallReading
{
    [Name("Device ID")]
    public string DeviceId { get; set; }

    [Name("Time")]
    public DateTime Timestamp { get; set; }

    [Name("Rainfall")]
    public double Rainfall { get; set; }
}