// <copyright file="TimeSeries.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

/// <summary>
/// Time series class.
/// </summary>
/// <param name="Values">Data points.</param>
internal record TimeSeries(IReadOnlyList<DataPoint> Values);
