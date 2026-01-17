namespace DataLoader.Records;

public record RecordContainerWithUniqueSymbol<T>(string Symbol, IReadOnlyList<T> Records) : RecordContainer<T>(Records)
    where T : BaseRecord;
