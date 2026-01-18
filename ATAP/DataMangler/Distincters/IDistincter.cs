namespace DataMangler.Distincters;

using Core;

public interface IDistincter<T>
{
    IReadOnlyList<DataPoint<T>> MakeDistinct(List<DataPoint<T>> rawDataPoints);
}
