using Application;


using Application.Services;

namespace WaterMeter.Tests;

public class WaterMeterLogicTests
{
    [Fact]
    public void CalculateConsumption_NormalIncrease_ReturnsExactDifference()
    {
        //input values
        decimal current = 1250.500m;
        decimal previous = 1200.000m;

        //call CalculateConsumption
        decimal result = WaterMeterLogic.CalculateConsumption(current, previous);

        //verify output matches expectations
        Assert.Equal(50.500m, result);

    }

    [Fact]
    public void DetectPotentialLeak_OccupiedBuilding_OverThreshold_ReturnsTrue()
    {
        //flow rate exceeds 500L/hour
        decimal suspiciousFlow = 650m;
        bool isOccupied = true;


        //Act
        //call DetectPotentialLeak
        var (isLeak, message) = WaterMeterLogic.DetectPotentialLeak(suspiciousFlow, isOccupied);

        //verify
        Assert.True(isLeak);
        Assert.Contains("Warning", message);
    }


    [Fact]
    public void IsReadingStale_LastReceivedOverThreshold_ReturnsTrue()
    {
        //threshold is 48 hours, test when values go above
        var twoDaysAgo = DateTimeOffset.UtcNow.AddHours(-50);
        var threshold = TimeSpan.FromHours(48);


        //Act
        //Call IsReadingStale method to test
        bool isStale = WaterMeterLogic.IsReadingStale(twoDaysAgo, threshold);


        //Assert
        //verify if output matches expectations
        Assert.True(isStale);
    }


    [Fact]
    public void ValidateReading_NegativeValue_ReturnsFalseWithError()
    {
        //test to see if negative value fails
        decimal negativeReading = -10m;



        //call method to test value
        var (isValid, errorMessage) = WaterMeterLogic.ValidateReading(negativeReading, previousReading: null);


        //verify
        Assert.False(isValid);
        Assert.Contains("cannot be negative", errorMessage);
    }


    [Fact]
    public void CalculateConsumption_MeterRollover_ReturnsCorrectWraparound()
    {
        //Test to see what happens when meter is below limit or above limit
        decimal current = 0.050m;
        decimal previous = 999_999.950m;


        //test values
        decimal result = WaterMeterLogic.CalculateConsumption(current, previous);



        //verify results
        Assert.Equal(0.099m, result);
    }
}
