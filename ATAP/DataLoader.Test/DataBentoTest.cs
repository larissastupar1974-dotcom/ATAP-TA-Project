// <copyright file="DataBentoTest.cs" company="LarissaStupar1974">
// Copyright (c) LarissaStupar1974. All rights reserved.
// </copyright>

namespace DataLoader.Test;

using DataLoader;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;
using Xunit.Sdk;
using DataLoader.Dto;
using DataLoader.Records;

/// <summary>
/// Test data bento loading.
/// </summary>
/// <param name="output">Test output helper.</param>
public class DataBentoTest(ITestOutputHelper output)
{
    private const string FilePath = @"C:\\MyData\Tfm1Yearohlcv-1d.csv";
    private const string SnippetPath = @"C:\\MyData\ohlcv-snippet.csv";
    private const string SnippetFileName = "ohlcv-snippet.csv";

    /// <summary>
    /// Convert snippet to dtos.
    /// </summary>
    /// <exception cref="Exception">Failed to load.</exception>
    [Fact]
    public void TestConvertSnippetToStandardDtos()
    {
        this.ConvertToStandardDtosSnippet();
    }

    /// <summary>
    /// Convert all records to dtos.
    /// </summary>
    /// <exception cref="Exception">Failed to load.</exception>
    [Fact]
    public void TestConvertToStandardDtos()
    {
         _= this.ConvertToStandardDtos(FilePath);
    }

    /// <summary>
    /// Test reading file snippet.
    /// </summary>
    [Fact]
    public void TestReadFileSnippet()
    {
        Assert.True(TryGetRecordsFromAbsoluteFilePath(SnippetPath, out _));
    }

    /// <summary>
    /// Test reading a file of the correct type with absolute path.
    /// </summary>
    /// <param name="filePath">absolute path.</param>
    /// <param name="expectedNumberOfRecords">Expected number of records in file.</param>
    [Theory]
    [InlineData(SnippetPath, 3)]
    [InlineData(FilePath, 228747)]
    public void TestReadFileAbsolutePath(string filePath, int expectedNumberOfRecords)
    {
        this.TestRecordNumberInFile(filePath, expectedNumberOfRecords);
    }

    /// <summary>
    /// Test number of records in a relatively specified filename.
    /// </summary>
    /// <param name="fileName">Filename.</param>
    /// <param name="expectedNumberOfRecords">Expected number of records.</param>
    [Theory]
    [InlineData(SnippetFileName, 3)]
    public void TestRecordNumberInRelativeFile(string fileName, int expectedNumberOfRecords)
    {
        string filePath = GetAbsoluteFilePath(fileName);
        this.TestRecordNumberInFile(filePath, expectedNumberOfRecords);
    }

    /// <summary>
    /// Test the missing file case.
    /// </summary>
    [Fact]
    public void MissingFileTest()
    {
        this.TestRecordNumberInFile("missingFile", 37);
    }

    /// <summary>
    /// Test the error message if we have the wrong number of records.
    /// </summary>
    [Fact]
    public void TestWrongNumberOfRows()
    {
        string filePath = GetAbsoluteFilePath(SnippetFileName);
        try
        {
            this.TestRecordNumberInFile(filePath, 37);
        }
        catch (Xunit.Sdk.EqualException ex)
        {
            string expectedError = "Assert.Equal() Failure: Values differ\r\nExpected: 37\r\nActual:   3";
            Assert.True(ex.Message == expectedError);
        }
    }

    /// <summary>
    /// Snippet to standard ohlcv.
    /// </summary>
    /// <returns>List of ohlcv.</returns>
    public RecordContainer<Ohlcv> ConvertToStandardDtosSnippet()
    {
        return this.ConvertToStandardDtos(GetAbsoluteFilePath(SnippetFileName));
    }

    /// <summary>
    /// File to standard ohlcv.
    /// </summary>
    /// <returns>List of ohlcv.</returns>
    public RecordContainer<Ohlcv> ConvertToStandardDtosFile()
    {
        return this.ConvertToStandardDtos(FilePath);
    }

    /// <summary>
    /// Get absolute file path - from filename and bin directory.
    /// </summary>
    /// <param name="fileName">Filename.</param>
    /// <returns>filePath.</returns>
    internal static string GetAbsoluteFilePath(string fileName)
    {
        string binDirectory = Path.Combine(Directory.GetCurrentDirectory());
        string filePath = Path.Combine(binDirectory, fileName);
        return filePath;
    }

    /// <summary>
    /// Get records from absolute filepath.
    /// </summary>
    /// <param name="filePath">FilePath.</param>
    /// <param name="records">output records.</param>
    /// <returns>File exists or not.</returns>
    internal static bool TryGetRecordsFromAbsoluteFilePath(string filePath, out DtoContainer<DataBentoOhlcv>? records)
    {
        bool exists = File.Exists(filePath);
        records = exists ? CsvReaderWriter.ReadDataBentoOhlcv(filePath) : null;
        return exists;
    }

    /// <summary>
    /// From absolute filepath assert number of records are the same as expected.
    /// </summary>
    /// <param name="filePath">Filepath.</param>
    /// <param name="expectedNumberOfRecords">Expected number of records.</param>
    internal void TestRecordNumberInFile(string filePath, int expectedNumberOfRecords)
    {
        if (TryGetRecordsFromAbsoluteFilePath(filePath, out DtoContainer<DataBentoOhlcv>? records) && records != null)
        {
            output.WriteLine($"File {filePath} has been found.");
            Assert.Equal(expectedNumberOfRecords, records.Dtos.Count);
        }
        else
        {
            output.WriteLine($"Filepath {filePath} is not found so no error thrown on record count.", OutputLevel.Warning);
        }
    }

    private RecordContainer<Ohlcv> ConvertToStandardDtos(string filePath)
    {
        if (TryGetRecordsFromAbsoluteFilePath(filePath, out DtoContainer<DataBentoOhlcv>? records) && records != null)
        {
            output.WriteLine("Got records.");
            return new([.. records.Dtos.Select(DataBentoConverter.ConvertOhlcv)]);
        }
        else
        {
            throw new Exception("Failed to load records.");
        }
    }
}