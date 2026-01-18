// <copyright file="TimeSeriesFactory.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler;

using Core;
using DataLoader.Records;
using DataMangler.Distincters;
using DataMangler.Pickers;

/// <summary>
/// Factory to make TimeSeries.
/// </summary>
public class TimeSeriesFactory
{
    /// <summary>
    /// Create nullable time series by picking one field from list of ohlcv.
    /// </summary>
    /// <param name="name">TimeSeries name.</param>
    /// <param name="ohlcvs">Raw ohlcv list.</param>
    /// <param name="picker">Field picker.</param>
    /// <returns>Nullable timeseries.</returns>
    public static TimeSeries<double?> Create(string name, RecordContainerWithUniqueSymbol<Ohlcv> ohlcvs, IPicker<Ohlcv> picker, IDistincter<double?> distincter)
    {
        List<DataPoint<double?>> rawPoints = [..ohlcvs.Records.Select(picker.GetValue)];
        var points = distincter.MakeDistinct(rawPoints);
        return new(name, points);
    }
}
