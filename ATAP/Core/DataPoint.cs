// <copyright file="DataPoint.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

/// <summary>
/// Time and value.
/// </summary>
/// <param name="TimeStamp">Time stamp.</param>
/// <param name="Value">Value.</param>
public record DataPoint(DateTime TimeStamp, double Value);
