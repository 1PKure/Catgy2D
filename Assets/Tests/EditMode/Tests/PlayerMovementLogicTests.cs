using NUnit.Framework;
using UnityEngine;

public class PlayerMovementLogicTests
{
    [Test]
    public void GetPositionForLane_ShouldReturnStartPosition_WhenLaneIsZero()
    {
        Vector3 startPosition = new Vector3(1f, 2f, 0f);
        PlayerMovementLogic movementLogic = new PlayerMovementLogic(2f, startPosition);

        Vector3 result = movementLogic.GetPositionForLane(0);

        Assert.AreEqual(startPosition.x, result.x);
        Assert.AreEqual(startPosition.y, result.y);
        Assert.AreEqual(startPosition.z, result.z);
    }

    [Test]
    public void GetPositionForLane_ShouldIncreaseY_ByLaneDistance()
    {
        Vector3 startPosition = new Vector3(1f, 2f, 0f);
        PlayerMovementLogic movementLogic = new PlayerMovementLogic(2f, startPosition);

        Vector3 result = movementLogic.GetPositionForLane(3);

        Assert.AreEqual(1f, result.x);
        Assert.AreEqual(8f, result.y);
        Assert.AreEqual(0f, result.z);
    }

    [Test]
    public void GetPositionForLane_ShouldKeepXAndZValues()
    {
        Vector3 startPosition = new Vector3(5f, -1f, 3f);
        PlayerMovementLogic movementLogic = new PlayerMovementLogic(2.5f, startPosition);

        Vector3 result = movementLogic.GetPositionForLane(2);

        Assert.AreEqual(5f, result.x);
        Assert.AreEqual(3f, result.z);
    }
}