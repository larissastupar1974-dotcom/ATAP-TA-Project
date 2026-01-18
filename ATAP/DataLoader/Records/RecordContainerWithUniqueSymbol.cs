// <copyright file="RecordContainerWithUniqueSymbol.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Records;

public record RecordContainerWithUniqueSymbol<T>(string Symbol, IReadOnlyList<T> Records) : RecordContainer<T>(Records)
    where T : BaseRecord;
