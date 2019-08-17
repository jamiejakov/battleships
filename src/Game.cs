using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
  public class Game
  {
    public Game()
    {
      this.Board = null;
      this.Ships = new List<Ship>();
    }

    Board Board;
    List<Ship> Ships;

    public void start()
    {
      char input = ' ';
      while (input != Constants.ACTION_EXIT)
      {
        if (isGameOver())
        {
          Console.WriteLine("Congratulations, all ships have been sunk!");
          input = Constants.ACTION_EXIT;
          return;
        }

        input = InputReader.getActionInput(Board, Ships);

        switch (input)
        {
          case Constants.ACTION_BUILD_MAP:
            buildMap();
            break;
          case Constants.ACTION_BUILD_SHIP:
            buildShip();
            break;
          case Constants.ACTION_ATTACK_SHIP:
            attackShip();
            break;
        }
      }
    }

    bool isGameOver()
    {
      return Board != null && Ships.Count != 0 && areAllShipsSunk();
    }

    bool areAllShipsSunk()
    {
      return Ships.Count(ship => ship.isSunk()) >= Ships.Count;
    }

    void buildMap()
    {
      if (Board != null)
      {
        throw new Exception("Battleship board has already been created, can not create another board.");
      }

      this.Board = BoardBuilder.buildBoard(Constants.BOARD_SIZE);
      Console.WriteLine("Battleship board has been created");
    }

    void buildShip()
    {
      if (Board == null)
      {
        throw new Exception("No Battleship board created. Create a board before adding ships.");
      }

      var startKey = InputReader.getShipStartKey();
      var length = InputReader.getShipLength();
      var direction = InputReader.getShipDirection();

      var ship = ShipBuilder.buildShip(Board.Map, startKey, length, direction);

      Ships.Add(ship);
    }

    void attackShip()
    {
      if (Board == null)
      {
        throw new Exception("No Battleship board created. Create a board before attacking.");
      }

      if (Ships.Count <= 0)
      {
        throw new Exception("No Battleship have been added to the board. Please add some ships before attacking.");
      }

      var position = InputReader.getAttackPosition();
      var positionCol = position[0];
      var positionRow = Int32.Parse(position[1].ToString());
      var cellToHit = Board.Map[positionCol][positionRow - 1];

      Console.WriteLine("");
      Console.WriteLine("");

      var hitResult = cellToHit.hit();

      switch (hitResult)
      {
        case HitCellResponse.ERROR:
          Console.WriteLine("You already hit this cell. Please try another cell.");
          break;
        case HitCellResponse.MISS:
          Console.WriteLine("You missed. Better luck next time.");
          break;
        case HitCellResponse.HIT:
          Console.WriteLine("You have hit a ship!");
          break;
      }
    }
  }
}