// <copyright file="Extensions.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader;

using System.Collections.Generic;
using System.Linq;
using DataLoader.Dto;

public static class Extensions
{
    public static IReadOnlyDictionary<string, IReadOnlyList<T>> GroupBySymbol<T>(this IReadOnlyList<T> records)
        where T : BaseRecord
    {
        Dictionary<string, List<T>> grouped = records.GroupBy(r => r.Symbol).ToDictionary(l => l.Key, l => l.ToList());
        return (IReadOnlyDictionary<string, IReadOnlyList<T>>)grouped;
    }
}
