// <copyright file="TimeSeriesExtensions.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

/// <summary>
/// Extension methods for NullableTimeSeries.
/// </summary>
public static class TimeSeriesExtensions
{
    /// <summary>
    /// Remove null data points and return a TimeSeries.
    /// </summary>
    /// <param name="nullableTimeSeries">NullbleTimeSeries.</param>
    /// <returns>TimeSeries.</returns>
    public static TimeSeries<double> ToTimeSeries(this TimeSeries<double?> nullableTimeSeries)
    {
        List<DataPoint<double>> dataPoints = [];
        foreach (DataPoint<double?> d in nullableTimeSeries.Values)
        {
            if (d.Value != null)
            {
                DataPoint<double> dataPoint = new(d.TimeStamp, d.Value.Value);
                dataPoints.Add(dataPoint);
            }
        }

        return new(nullableTimeSeries.Name, dataPoints);
    }

    /// <summary>
    /// Gets a list of time stamps whose value is null.
    /// </summary>
    /// <param name="nullableTimeSeries">Nullable time series.</param>
    /// <returns>TimeStamps of null datapoints.</returns>
    public static IReadOnlyList<DateTime> GetNulls(this TimeSeries<double?> nullableTimeSeries)
    {
        return [..nullableTimeSeries.Values.Where(v => v.Value == null).Select(s => s.TimeStamp)];
    }

    /// <summary>
    /// Gets how many null data points there are in the list of data points.
    /// </summary>
    /// <param name="nullableTimeSeries">Nullable time series.</param>
    /// <returns>Number of null data points.</returns>
    public static int NullCount(this TimeSeries<double?> nullableTimeSeries)
    {
        return nullableTimeSeries.Values.Where(v => v.Value == null).Count();
    }

    public static IReadOnlyList<DateTime> GetDistinctTimeStamps<T>(this List<DataPoint<T>> rawDataPoints)
    {
        return [.. rawDataPoints.Select(r => r.TimeStamp).Distinct().Order()];
    }

    public static IReadOnlyDictionary<DateTime, T> ToDictionary<T>(this TimeSeries<T> timeSeries)
    {
        return timeSeries.Values.ToDictionary(t => t.TimeStamp, t => t.Value);
    }

    public static T? GetValueOrNull<T>(this IReadOnlyDictionary<DateTime, T> dictionary, DateTime timeStamp)
    {
        dictionary.TryGetValue(timeStamp, out T? value);
        return value;
    }
}
