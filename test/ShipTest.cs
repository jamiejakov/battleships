using NUnit.Framework;
using System.Collections.Generic;

namespace Battleship.Tests
{
  [TestFixture]
  public class ShipTest
  {
    [Test]
    public void Construction_ShouldPlaceShipOnCells()
    {
      var cell1 = new Cell('A', 1);
      var cell2 = new Cell('A', 2);
      var cell3 = new Cell('A', 3);
      var shipCells = new List<Cell>() { cell1, cell2 };
      var ship = new Ship(shipCells);

      Assert.AreEqual(cell1.Ship, ship);
      Assert.AreEqual(cell2.Ship, ship);
      Assert.IsNull(cell3.Ship);
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