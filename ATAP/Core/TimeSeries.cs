namespace Core;

public record TimeSeries<T>
{
    private readonly IReadOnlyList<DataPoint<T>> values;

    public TimeSeries(string Name, IReadOnlyList<DataPoint<T>> RawValues)
    {
        int distinctElements = RawValues.Select(r => r.TimeStamp).Distinct().Count();
        if (distinctElements != RawValues.Count)
        {
            throw new ArgumentException($"Has {RawValues.Count - distinctElements} duplicate elements.");
        }

        this.values = [..RawValues.OrderBy(r => r.TimeStamp)];

        this.Name = Name;
    }

    public IReadOnlyList<DataPoint<T>> Values => this.values;

    public string Name { get; private set; }
}
