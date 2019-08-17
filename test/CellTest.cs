using NUnit.Framework;
using System.Collections.Generic;

namespace Battleship.Tests
{
  [TestFixture]
  public class CellTest
  {
    [Test]
    public void Hit_ShouldReturnError_WhenCellAlreadyHit()
    {
      var cell = new Cell('A', 1);
      cell.IsHit = true;

      var result = cell.hit();

      Assert.AreEqual(result, HitCellResponse.ERROR);
    }

    [Test]
    public void Hit_ShouldReturnMiss_WhenNoShipInCell()
    {
      var cell = new Cell('A', 1);

      var result = cell.hit();

      Assert.AreEqual(result, HitCellResponse.MISS);
    }

    [Test]
    public void Hit_ShouldReturnHit_WhenShipExists()
    {
      var cell = new Cell('A', 1);
      var shipCells = new List<Cell>() { cell };
      cell.Ship = new Ship(shipCells);

      var result = cell.hit();

      Assert.AreEqual(result, HitCellResponse.HIT);
    }

    [Test]
    public void Hit_ShouldSetIsHitToTrue_WhenShipExists()
    {
      var cell = new Cell('A', 1);
      var shipCells = new List<Cell>() { cell };
      new Ship(shipCells);

      var result = cell.hit();

      Assert.True(cell.IsHit);
    }

  }
}