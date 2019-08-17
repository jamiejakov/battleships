using System.Collections.Generic;

public class Board
{
  public Board(Dictionary<char, List<Cell>> map)
  {
    this.Map = map;
  }

  public Dictionary<char, List<Cell>> Map;
}

