//// <copyright file="Extensions.cs" company="LarissaStupar1974">
//// Copyright (c) LarissaStupar1974. All rights reserved.
//// </copyright>

//namespace DataLoader;

//using System.Collections.Generic;
//using System.Linq;
//using DataLoader.Records;

//public static class Extensions
//{
//    public static IReadOnlyList<RecordContainerWithUniqueSymbol<T>> GroupBySymbol<T>(this RecordContainer<T> records)
//        where T : BaseRecord
//    {
//        List<RecordContainerWithUniqueSymbol<T>> grouped = [];
//        foreach (var g in records.Records.GroupBy(r => r.Symbol))
//        {
//            var gr = new RecordContainerWithUniqueSymbol<T>(g.Key, g.ToList());
//            grouped.Add(gr);
//        }
//            //records.Records.GroupBy(r => r.Symbol).Select(l => new(l.Key, l.ToList()));
//        return grouped;
//    }
//}
