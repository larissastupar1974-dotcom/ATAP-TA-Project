// <copyright file="IPicker.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataMangler.Pickers;

using Core;

/// <summary>
/// Interface to pick NullableDataPoint from raw T value.
/// </summary>
/// <typeparam name="T">Type of record.</typeparam>
public interface IPicker<T>
{
    /// <summary>
    /// Pick NullableDataPoint from Raw Value T.
    /// </summary>
    /// <param name="rawValue">Raw Values.</param>
    /// <returns>Nullable Data Point.</returns>
    DataPoint<double?> GetValue(T rawValue);
}
