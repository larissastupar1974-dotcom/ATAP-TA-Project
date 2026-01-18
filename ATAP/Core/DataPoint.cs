// <copyright file="DataPoint.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace Core;

public record DataPoint<T>(DateTime TimeStamp, T Value);
