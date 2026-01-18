// <copyright file="OhlcvClosePicker.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler.Pickers;

using Core;
using DataLoader.Records;

/// <summary>
/// Picker Close from Ohlcv.
/// </summary>
public class OhlcvClosePicker : IPicker<Ohlcv>
{
    /// <inheritdoc/>
    public DataPoint<double?> GetValue(Ohlcv rawValue)
    {
        return new(rawValue.TimeStamp, rawValue.Close);
    }
}
