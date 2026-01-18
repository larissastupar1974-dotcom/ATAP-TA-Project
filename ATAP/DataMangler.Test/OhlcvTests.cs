// <copyright file="OhlcvTests.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler.Test;

using Core;
using DataLoader;
using DataLoader.Records;
using DataLoader.Test;
using DataMangler.Pickers;
using Xunit.Abstractions;

public class OhlcvTests(ITestOutputHelper output)
{
    [Fact]
    public void TestGetSnippetAsStandardDtos()
    {
        _ = this.GetSnippetAsStandardDtos();
    }

    [Fact]
    public void TestGetClosingNullableTimeSeriesFromSnippet()
    {
        _ = this.GetNullableTimeSeriesOfSnippetCloses();
    }

    [Fact]
    public void TestGetClosingNullableTimeSeriesFromFile()
    {
        _ = this.GetNullableTimeSeriesOfFileCloses();
    }

    [Fact]
    public void TestGetClosingTimeSeriesFromFile()
    {
        _ = this.GetTimeSeriesOfFileCloses();
    }

    [Theory]
    [InlineData(959)]
    public void TestNullableTimeSeriesFromFileNullCount(int expectedNulls)
    {
        IReadOnlyList<NullableTimeSeries> ts = this.GetNullableTimeSeriesOfFileCloses();
        int actualNulls = ts.Select(t => t.NullCount()).Max();
        //output.WriteLine($"{actualNulls.WithCommas()} out of {ts.Values.Count.WithCommas()} are null.");
        Assert.Equal(expectedNulls, actualNulls);
    }

    [Theory]
    [InlineData(959)]
    public void TestNullableTimeSeriesFromSnippetNullCount(int expectedNulls)
    {
        throw new NotImplementedException();
    }

    [Theory]
    [InlineData(1307)]
    public void TestTimeSeriesFromFile(int expectedNumber)
    {
        IReadOnlyList<NullableTimeSeries> nts = this.GetNullableTimeSeriesOfFileCloses();
        IReadOnlyList<TimeSeries> ts = [.. nts.Select(t => t.ToTimeSeries())];
        Assert.Equal(expectedNumber, ts.Count);
    }

    [Theory]
    [InlineData(1667, "TFM FYF0026.Z0026")]
    public void TestGetLongestTimeSeriesFromFile(int expectedNumber, string expectedName)
    {
        TimeSeries longest = this.GetLongestTimeSeries();
        Assert.Equal(expectedNumber, longest.Values.Count);
        Assert.Equal(expectedName, longest.Name);
    }

    public TimeSeries GetLongestTimeSeries()
    {
        IReadOnlyList<NullableTimeSeries> nts = this.GetNullableTimeSeriesOfFileCloses();
        IReadOnlyList<TimeSeries> ts = [.. nts.Select(t => t.ToTimeSeries())];
        TimeSeries longest = ts.OrderByDescending(t => t.Values.Count).First();
        return longest;
    }

    [Fact]
    public void TestWriteLongestTimeSeriesFromFileToCsv()
    {
        CsvReaderWriter.SaveToCSV<DataPoint>(this.GetLongestTimeSeries().Values);
    }

    [Theory]
    [InlineData(1307)]
    public void TestGetLongestTimeSeriesFromSnippet(int expectedNumber)
    {
        throw new NotImplementedException();
    }


    [Theory]
    [InlineData(959)]
    public void TestTimeSeriesFromSnippet(int expectedNulls)
    {
        throw new NotImplementedException();
    }

    [Fact]

    public void TestOhlcvGroupBySnippet()
    {
        RecordContainer<Ohlcv> stdDtos = this.GetSnippetAsStandardDtos();
        IReadOnlyList<RecordContainerWithUniqueSymbol<Ohlcv>> groupBy = UniqueRecordContainerFactory.Create(stdDtos);
    }

    [Fact]

    public void TestOhlcvGroupByFile()
    {
        RecordContainer<Ohlcv> stdDtos = this.GetFileAsStandardDtos();
        IReadOnlyList<RecordContainerWithUniqueSymbol<Ohlcv>> groupBy = UniqueRecordContainerFactory.Create(stdDtos);
    }

    private static NullableTimeSeries GetNullableTimeSeriesOfCloses(RecordContainerWithUniqueSymbol<Ohlcv> dtos)
    {
        var picker = new OhlcvClosePicker();
        var ts = TimeSeriesFactory.Create(dtos.Symbol, dtos, picker);
        return ts;
    }

    private List<TimeSeries> GetTimeSeriesOfFileCloses()
    {
        List<TimeSeries> ts = [..this.GetNullableTimeSeriesOfFileCloses().Select(t => t.ToTimeSeries())];
        return ts;
    }

    private IReadOnlyList<NullableTimeSeries> GetNullableTimeSeriesOfFileCloses()
    {
        IReadOnlyList<RecordContainerWithUniqueSymbol<Ohlcv>> groupBy = UniqueRecordContainerFactory.Create(this.GetFileAsStandardDtos());
        return [.. groupBy.Select(g => GetNullableTimeSeriesOfCloses(g))];
    }

    private IReadOnlyList<NullableTimeSeries> GetNullableTimeSeriesOfSnippetCloses()
    {
        IReadOnlyList<RecordContainerWithUniqueSymbol<Ohlcv>> groupBy = UniqueRecordContainerFactory.Create(this.GetSnippetAsStandardDtos());
        return [.. groupBy.Select(g => GetNullableTimeSeriesOfCloses(g))];
    }

    private RecordContainer<Ohlcv> GetSnippetAsStandardDtos()
    {
        DataBentoTest dbt = new(output);
        return dbt.ConvertToStandardDtosSnippet();
    }

    private RecordContainer<Ohlcv> GetFileAsStandardDtos()
    {
        DataBentoTest dbt = new(output);
        return dbt.ConvertToStandardDtosFile();
    }
}