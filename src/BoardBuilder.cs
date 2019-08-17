using System;
using System.Collections.Generic;
namespace Battleship
{
  static class MapBuilder
  {
    public static Board buildBoard(int size)
    {
      var map = new Dictionary<char, List<Cell>> { };

      for (var i = 0; i < size; i++)
      {
        var letter = Convert.ToChar(i + 65);
        var cells = new List<Cell>();

        for (var j = 1; j <= size; j++)
        {
          cells.Add(new Cell(letter, j));
        }

        map.Add(letter, cells);
      }

      return new Board(map);
    }
  }
}