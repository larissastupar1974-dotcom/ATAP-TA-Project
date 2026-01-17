// <copyright file="Ohlcv.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>
namespace DataLoader.DTO;

using DataLoader.Dto;

/// <summary>
/// Open High Low Close Volume.
/// Copied off DataBento but with typing.
/// </summary>
public record Ohlcv
    : BaseRecord
{
    /// <summary>
    /// Gets the timestamp of the event.
    /// </summary>
    public required DateTime TimeStamp { get; init; }

    /// <summary>
    /// Gets the record type.
    /// </summary>
    public required int RecordType { get; init; }

    /// <summary>
    /// Gets normalised name of publisher.
    /// </summary>
    public required int PublisherId { get; init; }

    /// <summary>
    /// Gets normalised name of instrument id.
    /// </summary>
    public required int InstrumentId { get; init; }

    /// <summary>
    /// Gets the Open price.
    /// </summary>
    public required double? Open { get; init; }

    /// <summary>
    /// Gets the High price.
    /// </summary>
    public required double? High { get; init; }

    /// <summary>
    /// Gets the Low price.
    /// </summary>
    public required double? Low { get; init; }

    /// <summary>
    /// Gets the Close price.
    /// </summary>
    public required double? Close { get; init; }

    /// <summary>
    /// Gets the Volume.
    /// </summary>
    public required double Volume { get; init; }
}
