// <copyright file="BaseRecord.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Dto;

public record BaseRecord
{
    /// <summary>
    /// Gets the Symbol.
    /// </summary>
    public required string Symbol { get; init; }
}
