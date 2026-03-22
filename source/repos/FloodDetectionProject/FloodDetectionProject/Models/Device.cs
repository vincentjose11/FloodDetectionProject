using CsvHelper.Configuration.Attributes;

public class Device
{
    [Name("Device ID")]
    public string DeviceId { get; set; }

    [Name("Device Name")]
    public string DeviceName { get; set; }

    [Name("Location")]
    public string Location { get; set; }
}