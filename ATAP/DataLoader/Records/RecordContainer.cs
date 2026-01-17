namespace DataLoader.Records;

using DataLoader.Dto;

public record RecordContainer<T>(IReadOnlyList<T> Records) : DtoContainer<T>(Records)
    where T : BaseRecord;
