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
    public void TestTimeSeriesFromFileNullCount(int expectedNulls)
    {
        var ts = this.GetNullableTimeSeriesOfFileCloses();
        int actualNulls = ts.Select(t => t.NullCount()).Max();
        //output.WriteLine($"{actualNulls.WithCommas()} out of {ts.Values.Count.WithCommas()} are null.");
        Assert.Equal(expectedNulls, actualNulls);
    }

    [Fact]

    public void TestOhlcvGroupBySnippet()
    {
        RecordContainer<Ohlcv> stdDtos = this.GetSnippetAsStandardDtos();
        IReadOnlyList<RecordContainerWithUniqueSymbol<Ohlcv>> groupBy = UniqueRecordContainerFactory.Create(stdDtos);
    }

    private static NullableTimeSeries GetNullableTimeSeriesOfCloses(RecordContainerWithUniqueSymbol<Ohlcv> dtos)
    {
        var picker = new OhlcvClosePicker();
        var ts = TimeSeriesFactory.Create("TestClosingTimeSeries", dtos, picker);
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