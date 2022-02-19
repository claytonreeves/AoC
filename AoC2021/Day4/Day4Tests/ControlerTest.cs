using Xunit;
using System.IO;
using System;
using System.Reflection;
using System.Linq;
using FluentAssertions;
using Day4;

namespace Day4Tests;

public class ControlerTest
{
    [Theory]
    [InlineData("Sample.dat", 3)]
    [InlineData("Full.dat", 100)]
    public void Given_Input_WhenStated_Then_ParseCorrrectly(string fileName, int numBoards)
    {
        // Given
        var input = ReadData(fileName);        

        // When
        var controler = new Controler(input);
    
        // Then
        controler.NumberOfBoards.Should().Be(numBoards);

    }

    [Theory]
    [InlineData("Sample.dat", 4512)]
    [InlineData("Full.dat", 50008)]
    public void Given_InputAndRunnigGameForFirst_Then_CorrectValueOut(string fileName, int Solution)
    {
        // Given
        var input = ReadData(fileName);

        // When
        var controler = new Controler(input);
    
        // Then
        controler.FindFirstWinningBoardNumber().Should().Be(Solution);
    }

    [Theory]
    [InlineData("Sample.dat", 1924)]
    [InlineData("Full.dat", 17408)]
    public void Given_InputAndRunnigGameForLast_Then_CorrectValueOut(string fileName, int Solution)
    {
        // Given
        var input = ReadData(fileName);

        // When
        var controler = new Controler(input);
    
        // Then
        controler.FindLastWinningBoardNumber().Should().Be(Solution);
    }

    [Theory]
    [InlineData("Sample.dat", 4512, 1)]
    [InlineData("Full.dat", 50008, 1)]
    [InlineData("Sample.dat", 1924, 3)]
    public void Given_InputAndRunnigGameForNth_Then_CorrectValueOut(string fileName, int Solution, int nth)
    {
        // Given
        var input = ReadData(fileName);

        // When
        var controler = new Controler(input);
    
        // Then
        controler.FindNthWinningBoardNumber(nth).Should().Be(Solution);
    }

    private static string ReadData(string input)
    {
        return TryRead($"Data/{input}");
    }

    private static string TryRead(string FilePath)
    {
        if (File.Exists(FilePath)) { return File.ReadAllText(FilePath); }
        else {
            var tmpD = Directory.EnumerateDirectories(".");
            var tmpF = Directory.EnumerateFiles(".");
        }
        return "";
    }
}