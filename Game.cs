using System;
using System.Collections.Generic;
using System.Linq;

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

      showActionOptions();
      input = Console.ReadKey().KeyChar;
      Console.WriteLine("");

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

  void showActionOptions()
  {
    Console.WriteLine("");
    Console.WriteLine("Welcome to Battleships. Please chose one of the following actions:");

    if (Board == null)
    {
      Console.WriteLine("'c' - Create the battleship board");
    }
    else
    {
      Console.WriteLine("'b' - Create a battleship");

      if (Ships.Count > 0)
      {
        Console.WriteLine("'a' - Attack a position on the board");
      }
    }

    Console.WriteLine("'x' - Exit the application");
  }

  void buildMap()
  {
    if (Board != null)
    {
      throw new Exception("Battleship board has already been created, can not create another board.");
    }

    this.Board = MapBuilder.buildBoard(10);
    Console.WriteLine("Battleship board has been created");
  }

  void buildShip()
  {
    if (Board == null)
    {
      throw new Exception("No Battleship board created. Create a board before adding ships.");
    }

    Console.WriteLine("Please enter the start position. (example: 'A1'; or 'F10')");
    var startKey = Console.ReadLine();

    Console.WriteLine("Please enter the ship length. (example: 5; or 10)");
    var length = Int32.Parse(Console.ReadLine());

    Console.WriteLine("Please enter the ship direction:");
    Console.WriteLine("'h' - horizontal (right from start position)");
    Console.WriteLine("'v' - vertical (down from start poisition)");
    var direction = Console.ReadKey().KeyChar;

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

    Console.WriteLine("Please enter the position to attack. (example: 'A1'; or 'F10')");
    var position = Console.ReadLine();

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