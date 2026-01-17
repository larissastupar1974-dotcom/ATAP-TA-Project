using DataLoader.Records;


namespace DataMangler;

public class UniqueRecordContainerFactory
{
    public static IReadOnlyList<RecordContainerWithUniqueSymbol<T>> Create<T>(RecordContainer<T> recordContainer)
        where T : BaseRecord
    {
        List<RecordContainerWithUniqueSymbol<T>> grouped = [];
        foreach (var g in recordContainer.Records.GroupBy(r => r.Symbol))
        {
            var gr = new RecordContainerWithUniqueSymbol<T>(g.Key, g.ToList());
            grouped.Add(gr);
        }
        //records.Records.GroupBy(r => r.Symbol).Select(l => new(l.Key, l.ToList()));
        return grouped;
        throw new NotImplementedException();
    }
}
