// <copyright file="ReadCsv.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader;

using System.Globalization;
using CsvHelper;
using DataLoader.Dto;

/// <summary>
/// Read csv.
/// </summary>
public static class ReadCsv
{
    /// <summary>
    /// Read from path to DataBentoOhlcv.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>Records.</returns>
    public static DtoContainer<DataBentoOhlcv> ReadDataBentoOhlcv(string path)
    {
        using StreamReader reader = new(path);
        using CsvReader csv = new(reader, CultureInfo.InvariantCulture);
        IEnumerable<DataBentoOhlcv> records = csv.GetRecords<DataBentoOhlcv>();
        return new([..records]);
    }
}
