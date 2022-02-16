using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Day4;
public class BingoBoard
{
    List<BingoBoardSpot> bingoBoard;

    public BingoBoard(string[] rawInput)
    {
        bingoBoard = new List<BingoBoardSpot>();

        for (int i = 0; i < rawInput.Length; i++)
        {
            var lineParts = rawInput[i].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < lineParts.Count(); j++)
            {
                bingoBoard.Add(new BingoBoardSpot{
                    Value = int.Parse(lineParts[j]),
                    Row = i,
                    Column = j,
                    IsSet = false
                });
            }
        }
    }

    public string PrintBoard()
    {
        StringBuilder outPut = new StringBuilder();
        foreach (var spot in bingoBoard)
        {
            outPut.Append(spot.ToString());
        }

        return outPut.ToString();
    }
}
