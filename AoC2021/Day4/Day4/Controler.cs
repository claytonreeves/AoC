using System;
using System.Collections.Generic;

namespace Day4;
public class Controler
{
    private List<int> _gameInput;
    private List<BingoBoard> _bingoBoards;
    private int _currentNumber = 0;

    public int NumberOfBoards => _bingoBoards.Count();
    public Controler(string input)
    {
        var split = input.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        _gameInput = split[0].Split(',').Select(int.Parse).ToList();

        _bingoBoards = new List<BingoBoard>();

        for (int i = 1; i < split.Count(); i++)
        {
            var boardInput = split[i].Split("\n");

            _bingoBoards.Add(new BingoBoard(boardInput));
        }
    }

    public int FindFirstWinningBoardNumber()
    {
        return FindNextWinningBoard();
    }

    public int FindLastWinningBoardNumber()
    {
        return FindNthWinningBoardNumber(_bingoBoards.Count);
    }

    public int FindNthWinningBoardNumber(int nth)
    {
        var returnBoardNumber = 0;

        for (int i = 0; i < nth; i++)
        {
            returnBoardNumber = FindNextWinningBoard();
        }

        return returnBoardNumber;
    }

    private int FindNextWinningBoard()
    {
        for (_currentNumber = 0; _currentNumber < _gameInput.Count; _currentNumber++)
        {
            foreach (var board in _bingoBoards)
            {
                var result = board.NumberCalled(_gameInput[_currentNumber]);
                if (result.Item1 && result.Item2 > 0)
                {
                    return result.Item2;
                }
            }
        }
        return 0;
    }

}
