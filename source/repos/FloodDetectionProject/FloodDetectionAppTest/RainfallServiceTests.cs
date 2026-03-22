using Xunit;
using System;
using System.Collections.Generic;
using FloodDetectionApp.Services;

public class RainfallServiceTests
{
    [Fact]
    public void GetTrend_ShouldReturnIncreasing_WhenValuesIncrease()
    {
        var service = new RainfallService();

        var readings = new List<RainfallReading>
        {
            new RainfallReading { Rainfall = 5, Timestamp = DateTime.Now.AddHours(-3) },
            new RainfallReading { Rainfall = 10, Timestamp = DateTime.Now.AddHours(-2) }
        };

        var result = service.GetTrend(readings);

        Assert.Equal("Increasing", result);
    }
}