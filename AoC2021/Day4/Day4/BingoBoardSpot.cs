namespace Day4;
public class BingoBoardSpot
{
    public int Value {get;set;}
    public bool IsSet {get;set;}
    public int Row {get;set;}
    public int Column {get;set;}

    public override string ToString()
    {
        return $"{Value} {Row} {Column} ";
    }
}
