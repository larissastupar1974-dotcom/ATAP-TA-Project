// <copyright file="ReadCsv.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader;

using CsvHelper;
using CsvHelper.Configuration;
using DataLoader.Dto;
using System.Globalization;
using System.Text;

/// <summary>
/// Read csv.
/// </summary>
public static class CsvReaderWriter
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

    // Source - https://stackoverflow.com/a
    // Posted by msmolcic, modified by community. See post 'Timeline' for change history
    // Retrieved 2026-01-18, License - CC BY-SA 4.0

    public static void SaveToCSV<T>(IReadOnlyList<T> records)
    {

        using (var writer = new StreamWriter("C:\\MyData\\file.csv"))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }
    }
}
