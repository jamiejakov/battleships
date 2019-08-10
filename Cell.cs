public class Cell
{
    public Cell(char column, int row)
    {
        this.Row = row;
        this.Column = column;
        this.Key = "" + column + row;
        this.Ship = null;
    }

    public int Row;
    public char Column;
    public string Key;

    public Ship Ship;
}