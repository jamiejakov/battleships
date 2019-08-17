using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
  public class Board
  {
    public Board(Dictionary<char, List<Cell>> map)
    {
      this.Map = map;
      this.Ships = new List<Ship>();
    }

    public Dictionary<char, List<Cell>> Map;
    public List<Ship> Ships;


    public bool areAllShipsSunk()
    {
      return Ships.Count != 0 && Ships.Count(ship => ship.isSunk()) >= Ships.Count;
    }
  }
}
