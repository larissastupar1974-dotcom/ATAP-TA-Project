// <copyright file="RecordContainer.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Records;

using DataLoader.Dto;

public record RecordContainer<T>(IReadOnlyList<T> Records) : DtoContainer<T>(Records)
    where T : BaseRecord;
