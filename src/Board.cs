using System.Collections.Generic;

namespace Battleship
{
  public class Board
  {
    public Board(Dictionary<char, List<Cell>> map)
    {
      this.Map = map;
    }

    public Dictionary<char, List<Cell>> Map;
  }

}
