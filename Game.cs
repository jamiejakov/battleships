using System;
using System.Collections.Generic;

public class Game
{
  public Game()
  {
    this.Map = null;
    this.Ships = new List<Ship>();
    this.SunkShipCount = 0;
  }

  Dictionary<char, List<Cell>> Map;
  List<Ship> Ships;

  int SunkShipCount;

  public void start()
  {
    char input = ' ';
    while (input != Constants.ACTION_EXIT)
    {
      if (Map != null && Ships.Count != 0 && SunkShipCount >= Ships.Count)
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

  void showActionOptions()
  {
    Console.WriteLine("");
    Console.WriteLine("Welcome to Battleships. Please chose one of the following actions:");

    if (Map == null)
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
    if (Map != null)
    {
      throw new Exception("Battleship board has already been created, can not create another board.");
    }

    this.Map = MapBuilder.buildMap(10);
    Console.WriteLine("Battleship board has been created");
  }

  void buildShip()
  {
    if (Map == null)
    {
      throw new Exception("No Battleship board created. Create a board before adding ships.");
    }

    Console.WriteLine("Please enter the start position. (example: 'A1'; or 'F10')");
    var startKey = Console.ReadLine();

    Console.WriteLine("Please enter the ship length. (example: 5; or 10)");
    var length = Int32.Parse(Console.ReadLine());

    Console.WriteLine("Please enter the ship direction:");
    Console.WriteLine("'h' - horizontal");
    Console.WriteLine("'v' - vertical");
    var direction = Console.ReadKey().KeyChar;

    var ship = ShipBuilder.buildShip(Map, startKey, length, direction);

    Ships.Add(ship);
  }

  void attackShip()
  {
    if (Map == null)
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
    var hitCell = Map[positionCol][positionRow - 1];

    Console.WriteLine("");
    Console.WriteLine("");

    if (hitCell.IsHit)
    {
      Console.WriteLine("You already hit this cell. Please try another cell.");
      return;
    }

    if (hitCell.Ship == null)
    {
      Console.WriteLine("You missed. Better luck next time.");
      return;
    }

    Console.WriteLine("You have hit a ship!");
    hitCell.Ship.hit();

    if (hitCell.Ship.isSunk())
    {
      SunkShipCount += 1;
    }

    hitCell.IsHit = true;
  }
}