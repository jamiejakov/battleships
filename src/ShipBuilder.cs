using System;
using System.Collections.Generic;

namespace Battleship
{
  static class ShipBuilder
  {
    public static Ship buildShip(Dictionary<char, List<Cell>> map, string startKey, int length, char direction)
    {
      var startKeyCol = startKey[0];
      var startKeyRow = Int32.Parse(startKey[1].ToString());
      var startCell = map[startKeyCol][startKeyRow - 1];

      if (direction == Constants.DIRECTION_VERTICAL)
      {
        var newLocations = new List<Cell>();
        var endKeyRow = startKeyRow + length;

        validateShipSize(endKeyRow);

        for (var i = startKeyRow; i < endKeyRow; i++)
        {
          var newLocation = map[startKeyCol][i - 1];
          newLocations.Add(newLocation);
        }

        return new Ship(newLocations);
      }

      if (direction == Constants.DIRECTION_HORIZONTAL)
      {
        var newLocations = new List<Cell>();
        var startNum = Convert.ToInt32(startKeyCol);
        var endNum = startNum + length;

        validateShipSize(endNum);

        for (var i = startNum; i < endNum; i++)
        {
          var letter = Convert.ToChar(i);
          var newLocation = map[letter][startKeyRow - 1];
          newLocations.Add(newLocation);
        }

        return new Ship(newLocations);
      }

      throw new Exception("Unknown direction was provided, can not construct ship");
    }

    static void validateShipSize(int endKey)
    {
      if (endKey > Constants.BOARD_SIZE)
      {
        throw new Exception("Ship will go out of bounds of the board.");
      }
    }
  }
}