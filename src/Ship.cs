using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
  public class Ship
  {
    public Ship(List<Cell> cells)
    {
      this.Cells = cells;

      place();
    }

    public List<Cell> Cells;

    public bool isSunk()
    {
      return Cells.All(cell => cell.IsHit);
    }

    void place()
    {
      foreach (var cell in Cells)
      {
        cell.Ship = this;
      }
    }
  }


}