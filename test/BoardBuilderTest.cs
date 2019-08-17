using NUnit.Framework;

namespace Battleship.Tests
{
  [TestFixture]
  public class BoardBuilderTest
  {
    [Test]
    public void BuildBoard_ShouldBuildBoardCorrectly()
    {
      var board = BoardBuilder.buildBoard(2);
      var map = board.Map;

      Assert.NotNull(map['A'][0]);
      Assert.NotNull(map['A'][1]);
      Assert.NotNull(map['B'][0]);
      Assert.NotNull(map['B'][1]);
      Assert.AreEqual(map['A'][0].Key, "A1");
      Assert.AreEqual(map['A'][1].Key, "A2");
      Assert.AreEqual(map['B'][0].Key, "B1");
      Assert.AreEqual(map['B'][1].Key, "B2");
    }
  }
}