using System;
using System.Collections.Generic;

namespace Battleship
{
  public static class InputReader
  {
    public static char getActionInput(Board board)
    {
      char input;
      Console.WriteLine("");
      Console.WriteLine("Welcome to Battleships. Please chose one of the following actions:");

      if (board == null)
      {
        Console.WriteLine("'c' - Create the battleship board");
      }
      else
      {
        Console.WriteLine("'b' - Create a battleship");

        if (board.Ships.Count > 0)
        {
          Console.WriteLine("'a' - Attack a position on the board");
        }
      }

      Console.WriteLine("'x' - Exit the application");

      input = Console.ReadKey().KeyChar;
      Console.WriteLine("");

      return input;
    }

    public static int getShipLength()
    {
      var length = 0;
      var loopCount = 0;

      while (length < 1 || length > 10)
      {
        if (loopCount != 0)
        {
          Console.WriteLine("");
          Console.WriteLine("You entered an incorrect ship length. Must be between 1 and 10");
        }

        Console.WriteLine("Please enter the ship length. (between 1 and 10)");
        length = Int32.Parse(Console.ReadLine());
        loopCount++;
      };

      return length;
    }

    public static char getShipDirection()
    {
      char direction = ' ';
      var loopCount = 0;

      while (direction != Constants.DIRECTION_HORIZONTAL && direction != Constants.DIRECTION_VERTICAL)
      {
        if (loopCount != 0)
        {
          Console.WriteLine("");
          Console.WriteLine("You entered an incorrect direction, please enter 'v' for vertical or 'h' for horizontal.");
        }

        Console.WriteLine("Please enter the ship direction:");
        Console.WriteLine("'h' - horizontal (right from start position)");
        Console.WriteLine("'v' - vertical (down from start poisition)");
        direction = Console.ReadKey().KeyChar;
        loopCount++;
      };

      return direction;
    }

    public static string getShipStartKey()
    {
      Console.WriteLine("Please enter the start position. (example: 'A1'; or 'F10')");
      var startKey = Console.ReadLine();

      return startKey;
    }

    public static string getAttackPosition()
    {
      Console.WriteLine("Please enter the position to attack. (example: 'A1'; or 'F10')");
      var position = Console.ReadLine();

      return position;
    }
  }
}