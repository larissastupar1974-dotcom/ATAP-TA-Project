namespace SignalGenerator;

using Core;
using System.Collections.Generic;

public static class TimeSeriesUtilities
{
    public static TimeSeries<double> SimpleMovingAverage(this TimeSeries<double> timeSeries, ushort window)
    {
        List<DataPoint<double>> movingAverage = [];
        int numberOfSamples = timeSeries.Values.Count;
        int firstIndex = window - 1;
        for (int i = firstIndex; i < numberOfSamples; i++)
        {
            List<double> series = [];
            for (int j = i - window + 1; j < i; j++)
            {
                double value = timeSeries.Values[j].Value;
                series.Add(value);
            }

            DateTime dateStamp = timeSeries.Values[i].TimeStamp;
            double ma = series.Average();
            movingAverage.Add(new DataPoint<double>(dateStamp, ma));
        }

        return new TimeSeries<double>(timeSeries.Name + "_MovingAverage_" + window, movingAverage);
    }

    public static MultiTimeSeries<double?> ToMultiSeries(List<TimeSeries<double>> listOfTimeSeries)
    {
        List<IReadOnlyDictionary<DateTime, double>> asDictionaries = [.. listOfTimeSeries.Select(l => l.ToDictionary())];
        List<DateTime> allDates = [.. asDictionaries.SelectMany(d => d.Keys).Distinct().Order()];
        List<DataPoint<List<double?>>> multiDataPoints = [];
        List<int> tsList = [.. Enumerable.Range(0, listOfTimeSeries.Count)];
        foreach (DateTime date in allDates)
        {
            List<double?> multi = [..tsList.Select(i => asDictionaries[i].GetValueOrNull(date))];
            multiDataPoints.Add(new(date, multi));
;       }

        List<string> listOfNames = [..listOfTimeSeries.Select(t => t.Name)];
        string multiName = string.Join(",", listOfNames);
        return new (listOfNames, new(multiName, multiDataPoints));
    }
}
