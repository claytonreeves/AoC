using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Day4;
public class BingoBoard
{
    private List<BingoBoardSpot> _bingoBoard;
    private List<int> _columnTracker = new List<int>();
    private int _columsTotal;
    private List<int> _rowTracker = new List<int>();
    private int _rowTotal;
    private bool _solved = false;

    public BingoBoard(string[] rawInput)
    {
        _bingoBoard = new List<BingoBoardSpot>();
        
        _rowTotal = rawInput.Length;
        for (int i = 0; i < _rowTotal; i++)
        {
            var lineParts = rawInput[i].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            _columsTotal = lineParts.Count();

            for (int j = 0; j < lineParts.Count(); j++)
            {
                _bingoBoard.Add(new BingoBoardSpot{
                    Value = int.Parse(lineParts[j]),
                    Row = i,
                    Column = j,
                    IsSet = false
                });
            }
            _rowTracker.Add(0);
        }
        _columnTracker = Enumerable.Repeat<int>(0,_columsTotal).ToList();
    }

    public string PrintBoard()
    {
        StringBuilder outPut = new StringBuilder();
        foreach (var spot in _bingoBoard)
        {
            outPut.Append(spot.ToString());
        }

        return outPut.ToString();
    }

    public (bool, int) NumberCalled(int numberCalled)
    {
        var returnInt = 0;

        if(_solved)
        {
            return (_solved,-1);
        }

        foreach (var spot in _bingoBoard)
        {
            if (spot.Value == numberCalled && !spot.IsSet)
            {
                spot.IsSet = true;
                _rowTracker[spot.Row]++;
                _columnTracker[spot.Column]++;

                if (_rowTracker.Where(r => r == _rowTotal).Any()
                    || _columnTracker.Where(r => r == _columsTotal).Any())
                {
                    _solved = true;
                    returnInt = SumOfUnSetSpots() * numberCalled;
                }
            }
        }

        return (_solved, returnInt);
    }

    private int SumOfUnSetSpots()
    {
        return _bingoBoard.Where(s => !s.IsSet).Select(s => s.Value).Sum();
    }
}
