using Xunit.Abstractions;

namespace SignalGenerator.Test;

public class UnitTest1(ITestOutputHelper output)
{

    [Fact]
    public void TestDataGetting()
    {
        DataMangler.Test.OhlcvTests ohlcvTests = new(output);
        var longest = ohlcvTests.GetLongestTimeSeries();
    }
}