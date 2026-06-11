using NUnit.Framework;

public class PlayerModelTests
{
    [Test]
    public void Constructor_ShouldStartAtMinLane()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        Assert.AreEqual(0, playerModel.CurrentLane);
    }

    [Test]
    public void CanMoveToLane_ShouldReturnTrue_WhenLaneIsValid()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        bool canMove = playerModel.CanMoveToLane(2);

        Assert.IsTrue(canMove);
    }

    [Test]
    public void CanMoveToLane_ShouldReturnFalse_WhenLaneIsBelowMin()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        bool canMove = playerModel.CanMoveToLane(-1);

        Assert.IsFalse(canMove);
    }

    [Test]
    public void CanMoveToLane_ShouldReturnFalse_WhenLaneIsAboveMax()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        bool canMove = playerModel.CanMoveToLane(5);

        Assert.IsFalse(canMove);
    }

    [Test]
    public void TrySetCurrentLane_ShouldChangeLane_WhenLaneIsValid()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        bool result = playerModel.TrySetCurrentLane(3);

        Assert.IsTrue(result);
        Assert.AreEqual(3, playerModel.CurrentLane);
    }

    [Test]
    public void TrySetCurrentLane_ShouldNotChangeLane_WhenLaneIsInvalid()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);

        bool result = playerModel.TrySetCurrentLane(10);

        Assert.IsFalse(result);
        Assert.AreEqual(0, playerModel.CurrentLane);
    }

    [Test]
    public void Reset_ShouldReturnPlayerToMinLane()
    {
        PlayerModel playerModel = new PlayerModel(0, 4);
        playerModel.TrySetCurrentLane(3);

        playerModel.Reset();

        Assert.AreEqual(0, playerModel.CurrentLane);
    }
}