// <copyright file="DataBentoConverter.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Dto;

using DataLoader.Records;

/// <summary>
/// Convert from DataBento to standard schema.
/// </summary>
internal static class DataBentoConverter
{
    /// <summary>
    /// Convert open high low close volume records.
    /// </summary>
    /// <param name="dataBentoOhlcv">Data bento type.</param>
    /// <returns>standard type.</returns>
    public static Ohlcv ConvertOhlcv(DataBentoOhlcv dataBentoOhlcv)
    {
        return new Ohlcv
        {
            Close = ToDoubleOrNull(dataBentoOhlcv.close),
            High = ToDoubleOrNull(dataBentoOhlcv.high),
            InstrumentId = ToInt(dataBentoOhlcv.instrument_id),
            Low = ToDoubleOrNull(dataBentoOhlcv.low),
            Open = ToDoubleOrNull(dataBentoOhlcv.open),
            PublisherId = ToInt(dataBentoOhlcv.publisher_id),
            RecordType = ToInt(dataBentoOhlcv.rtype),
            TimeStamp = ToDateTIme(dataBentoOhlcv.ts_event),
            Volume = ToDouble(dataBentoOhlcv.volume),
            Symbol = dataBentoOhlcv.symbol,
        };
    }

    private static double? ToDoubleOrNull(string rawString)
    {
        if (double.TryParse(rawString, out double result))
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    private static double ToDouble(string rawString) => double.Parse(rawString);

    private static int ToInt(string rawString) => int.Parse(rawString);

    private static DateTime ToDateTIme(string rawString) => DateTime.Parse(rawString);
}
