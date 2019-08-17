using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Battleship.Tests
{
  [TestFixture]
  public class ShipBuilderTest
  {
    [Test]
    public void BuildShip_Vertical_Correctly()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      var ship = ShipBuilder.buildShip(map, "A1", 2, Constants.DIRECTION_VERTICAL);

      Assert.AreEqual(map['A'][0].Ship, ship);
      Assert.AreEqual(map['A'][1].Ship, ship);
      Assert.IsNull(map['A'][2].Ship);
    }

    [Test]
    public void BuildShip_Vertical_DoesntGoOutOfBounds()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      TestDelegate buildShipDelegate = () => ShipBuilder.buildShip(map, "A9", 5, Constants.DIRECTION_VERTICAL);

      var exception = Assert.Throws<Exception>(buildShipDelegate);
      Assert.AreEqual(exception.Message, "Ship will go out of bounds of the board.");
    }

    [Test]
    public void BuildShip_Vertical_DoesntCreateShipLargerThanBoard()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      TestDelegate buildShipDelegate = () => ShipBuilder.buildShip(map, "A1", 200, Constants.DIRECTION_VERTICAL);

      var exception = Assert.Throws<Exception>(buildShipDelegate);
      Assert.AreEqual(exception.Message, "Ship will go out of bounds of the board.");
    }

    [Test]
    public void BuildShip_Horizontal_Correctly()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      var ship = ShipBuilder.buildShip(map, "A1", 2, Constants.DIRECTION_HORIZONTAL);

      Assert.AreEqual(map['A'][0].Ship, ship);
      Assert.AreEqual(map['B'][0].Ship, ship);
      Assert.IsNull(map['C'][0].Ship);
    }

    [Test]
    public void BuildShip_Horizontal_DoesntGoOutOfBounds()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      TestDelegate buildShipDelegate = () => ShipBuilder.buildShip(map, "J1", 5, Constants.DIRECTION_HORIZONTAL);

      var exception = Assert.Throws<Exception>(buildShipDelegate);
      Assert.AreEqual(exception.Message, "Ship will go out of bounds of the board.");
    }

    [Test]
    public void BuildShip_Horizontal_DoesntCreateShipLargerThanBoard()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      TestDelegate buildShipDelegate = () => ShipBuilder.buildShip(map, "A1", 200, Constants.DIRECTION_HORIZONTAL);

      var exception = Assert.Throws<Exception>(buildShipDelegate);
      Assert.AreEqual(exception.Message, "Ship will go out of bounds of the board.");
    }

    [Test]
    public void BuildShip_UnknownDirection_ShouldThrow()
    {
      var map = BoardBuilder.buildBoard(Constants.BOARD_SIZE).Map;

      TestDelegate buildShipDelegate = () => ShipBuilder.buildShip(map, "A1", 200, '8');

      var exception = Assert.Throws<Exception>(buildShipDelegate);
      Assert.AreEqual(exception.Message, "Unknown direction was provided, can not construct ship");
    }

    [Test]
    public void IsSunk_ShouldReturnTrue_WhenAllCellsArehit()
    {
      var cell = new Cell('A', 1);
      var shipCells = new List<Cell>() { cell };
      var ship = new Ship(shipCells);

      Assert.False(ship.isSunk());

      cell.IsHit = true;

      Assert.True(ship.isSunk());
    }

  }
}