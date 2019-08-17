using NUnit.Framework;

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

      Assert.Equals(result, HitCellResponse.ERROR);
    }
  }
}