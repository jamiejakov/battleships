using System.Collections.Generic;

public class Ship
{
  public Ship(List<Cell> cells)
  {
    this.Cells = cells;
    this.HitCount = 0;

    place();
  }

  public List<Cell> Cells;
  public int HitCount;

  public void hit()
  {
    this.HitCount += 1;
  }

  public bool isSunk()
  {
    return this.HitCount >= this.Cells.Count;
  }

  void place()
  {
    foreach (var cell in Cells)
    {
      cell.Ship = this;
    }
  }
}

