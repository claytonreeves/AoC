using Xunit;
using FluentAssertions;
using Day4;

namespace Day4Tests;

public class BingoBoardTest
{
    [Fact]
    public void WhenGivenBoardParsedCorrectly()
    {
        string[] input = {"6 7","7 6"};
        var first = new BingoBoardSpot{
            Value = 6,
            Row = 0,
            Column = 0,
            IsSet = false
        };

        var expectedValue = "6 0 0 7 0 1 7 1 0 6 1 1 ";

        var testBoard = new BingoBoard(input);

        var testBoardString = testBoard.PrintBoard();

        testBoardString.Should().Be(expectedValue);

    }

    [Fact]
    public void WhenGivenBoardParsedCorrectly2()
    {
        string[] input = {"6 7 8","8 7 6"};
        var first = new BingoBoardSpot{
            Value = 6,
            Row = 0,
            Column = 0,
            IsSet = false
        };

        var expectedValue = "6 0 0 7 0 1 8 0 2 8 1 0 7 1 1 6 1 2 ";

        var testBoard = new BingoBoard(input);

        var testBoardString = testBoard.PrintBoard();

        testBoardString.Should().Be(expectedValue);

    }
}