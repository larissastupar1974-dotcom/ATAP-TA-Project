// <copyright file="UnitTest1.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

using Core;
using DataLoader;
using DataMangler.Test;
using Xunit.Abstractions;

namespace SignalGenerator.Test;

public class UnitTest1(ITestOutputHelper output)
{

    [Fact]
    public void TestDataGetting()
    {
        _ = this.GetData();
    }

    [Fact]
    public void TestMovingAverage()
    {
        TimeSeries<double> longest = new OhlcvTests(output).GetLongestTimeSeries();
        _ = TimeSeriesUtilities.SimpleMovingAverage(longest, 20);
    }

    [Fact]
    public void TestWriteMovingAverageToCsv()
    {
        TimeSeries<double> longest = new OhlcvTests(output).GetLongestTimeSeries();
        TimeSeries<double> movingAverage = TimeSeriesUtilities.SimpleMovingAverage(longest, 20);
        var multi = TimeSeriesUtilities.ToMultiSeries([longest, movingAverage]);
        CsvReaderWriter.SaveToCSV<DataPoint<List<double?>>>(multi.Values, "C:\\MyData\\ma20.csv");
    }

    private TimeSeries<double> GetData()
    {
        DataMangler.Test.OhlcvTests ohlcvTests = new(output);
        TimeSeries<double> longest = ohlcvTests.GetLongestTimeSeries();
        return longest;
    }
}