using System;
using System.Collections.Generic;

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
            for (var i = startKeyRow; i < startKeyRow + length; i++)
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

            for (var i = startNum; i < startNum + length; i++)
            {
                var letter = Convert.ToChar(i);
                var newLocation = map[letter][startKeyRow - 1];
                newLocations.Add(newLocation);
            }

            return new Ship(newLocations);
        }

        throw new Exception("Unknown direction was provided, can not construct ship");
    }
}