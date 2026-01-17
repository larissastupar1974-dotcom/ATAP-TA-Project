// <copyright file="DataBentoOhlcv.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Dto;

/// <summary>
/// Data schema for DataBento OHLCV https://databento.com/.
/// </summary>
public record DataBentoOhlcv
{
    /// <summary>
    /// Gets the timestamp of the event.
    /// </summary>
    public required string ts_event { get; init; }

    /// <summary>
    /// Gets the record type.
    /// </summary>
    public required string rtype { get; init; }

    /// <summary>
    /// Gets normalised name of publisher.
    /// </summary>
    public required string publisher_id { get; init; }

    /// <summary>
    /// Gets normalised name of instrument id.
    /// </summary>
    public required string instrument_id { get; init; }

    /// <summary>
    /// Gets the Open price.
    /// </summary>
    public required string open { get; init; }

    /// <summary>
    /// Gets the High price.
    /// </summary>
    public required string high { get; init; }

    /// <summary>
    /// Gets the Low price.
    /// </summary>
    public required string low { get; init; }

    /// <summary>
    /// Gets the Close price.
    /// </summary>
    public required string close { get; init; }

    /// <summary>
    /// Gets the Volume.
    /// </summary>
    public required string volume { get; init; }

    /// <summary>
    /// Gets the Symbol.
    /// </summary>
    public required string symbol { get; init; }
}
