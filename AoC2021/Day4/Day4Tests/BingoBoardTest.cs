using Xunit;
using System.Collections.Generic;
using FluentAssertions;
using Day4;

namespace Day4Tests;

public class BingoBoardTest
{
    [Fact]
    public void WhenGivenBoardParsedCorrectly2x2()
    {
        string[] input = {"6 7","7 6"};

        var expectedValue = "6 0 0 7 0 1 7 1 0 6 1 1 ";

        var testBoard = new BingoBoard(input);

        var testBoardString = testBoard.PrintBoard();

        testBoardString.Should().Be(expectedValue);

    }

    [Fact]
    public void WhenGivenBoardParsedCorrectly3x2()
    {
        string[] input = {"6 7 8","8 7 6"};

        var expectedValue = "6 0 0 7 0 1 8 0 2 8 1 0 7 1 1 6 1 2 ";

        var testBoard = new BingoBoard(input);

        var testBoardString = testBoard.PrintBoard();

        testBoardString.Should().Be(expectedValue);

    }
    
    [Fact]
    public void WhenGivenBoardParsedCorrectly3x3()
    {     
        // Given BuildBoard(1)
        var expectedValue = "6 0 0 7 0 1 8 0 2 1 1 0 1 1 1 1 1 2 8 2 0 7 2 1 6 2 2 ";

        // When
        var testBoard = BuildBoard(1);

        var testBoardString = testBoard.PrintBoard();

        // Then
        testBoardString.Should().Be(expectedValue);

    }

    [Fact]
    public void Given_NumberCalled_When_NoNumberOnBoard_ThenReturnIfBingo()
    {
        // Given BuildBoard(1)
        var expectedValue = (false,0);
        // When 2 is called
        var isWinning = BuildBoard(1).NumberCalled(2);
    
        // Then
        isWinning.Should().Be(expectedValue);
    }

    [Fact]
    public void Given_1Called_When_NumberOnBoard_ThenReturnBingoForRow()
    {
        // Given BuildBoard(1)
        var expectedValue = (true,42);
        // When
        var isWinning = BuildBoard(1).NumberCalled(1);
    
        // Then
        isWinning.Should().Be(expectedValue);
    }

    [Fact]
    public void Given_1Called_When_NumberOnBoard_ThenReturnBingoForColumn()
    {
        // Given BuildBoard(1)
        var expectedValue = (true,210);
        // When
        var isWinning = BuildBoard(2).NumberCalled(7);
    
        // Then
        isWinning.Should().Be(expectedValue);
    }

    [Fact]
    public void Given_BoardIsSolved_When_NumberCalled_BoardWontCalcAgain()
    {
        // Given
        var expectedValue = (true,-1);
    
        // When
        var board = BuildBoard(1);
        board.NumberCalled(1);
        var result = board.NumberCalled(1);
    
        // Then
        result.Should().Be(expectedValue);
    }

   private BingoBoard BuildBoard(int version = 1)
   {
       List<string> boardText;
       switch (version)
       {
           case 1:
            boardText = new List<string> {"6 7 8","1 1 1","8 7 6"};
            break;
           case 2:
            boardText = new List<string> {"6 7 8","1 7 1","8 7 6"};
            break;
           default:
           throw new KeyNotFoundException();
       }
        return new BingoBoard(boardText.ToArray());
   }
}