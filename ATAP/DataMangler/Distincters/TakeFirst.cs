using Core;

namespace DataMangler.Distincters;

public class TakeFirst<T> : IDistincter<T>
{
    public IReadOnlyList<DataPoint<T>> MakeDistinct(List<DataPoint<T>> rawDataPoints)
    {
        List<DataPoint<T>> distinct = [];
        DateTime previousTimeStamp = DateTime.MinValue;
        foreach (DataPoint<T> rawDataPoint in rawDataPoints)
        {
            DateTime currentTimeStamp = rawDataPoint.TimeStamp;
            if (currentTimeStamp != previousTimeStamp)
            {
                distinct.Add(rawDataPoint);
                previousTimeStamp = currentTimeStamp;
            }
        }
        return distinct;
    }
}
