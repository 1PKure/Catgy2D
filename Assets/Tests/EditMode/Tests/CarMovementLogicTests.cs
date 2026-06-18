using NUnit.Framework;
using UnityEngine;

public class CarMovementLogicTests
{
    [Test]
    public void GetNextPosition_ShouldMoveRight_WhenDirectionIsPositive()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, 1, 10f);
        Vector3 startPosition = Vector3.zero;

        Vector3 result = movementLogic.GetNextPosition(startPosition, 0.5f);

        Assert.AreEqual(2f, result.x);
        Assert.AreEqual(0f, result.y);
        Assert.AreEqual(0f, result.z);
    }

    [Test]
    public void GetNextPosition_ShouldMoveLeft_WhenDirectionIsNegative()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, -1, -10f);
        Vector3 startPosition = Vector3.zero;

        Vector3 result = movementLogic.GetNextPosition(startPosition, 0.5f);

        Assert.AreEqual(-2f, result.x);
        Assert.AreEqual(0f, result.y);
        Assert.AreEqual(0f, result.z);
    }

    [Test]
    public void ShouldDestroy_ShouldReturnTrue_WhenMovingRightAndReachesDestroyPosition()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, 1, 10f);

        bool shouldDestroy = movementLogic.ShouldDestroy(new Vector3(10f, 0f, 0f));

        Assert.IsTrue(shouldDestroy);
    }

    [Test]
    public void ShouldDestroy_ShouldReturnFalse_WhenMovingRightAndHasNotReachedDestroyPosition()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, 1, 10f);

        bool shouldDestroy = movementLogic.ShouldDestroy(new Vector3(9.9f, 0f, 0f));

        Assert.IsFalse(shouldDestroy);
    }

    [Test]
    public void ShouldDestroy_ShouldReturnTrue_WhenMovingLeftAndReachesDestroyPosition()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, -1, -10f);

        bool shouldDestroy = movementLogic.ShouldDestroy(new Vector3(-10f, 0f, 0f));

        Assert.IsTrue(shouldDestroy);
    }

    [Test]
    public void ShouldDestroy_ShouldReturnFalse_WhenMovingLeftAndHasNotReachedDestroyPosition()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, -1, -10f);

        bool shouldDestroy = movementLogic.ShouldDestroy(new Vector3(-9.9f, 0f, 0f));

        Assert.IsFalse(shouldDestroy);
    }

    [Test]
    public void ShouldDestroy_ShouldReturnFalse_WhenDirectionIsZero()
    {
        CarMovementLogic movementLogic = new CarMovementLogic(4f, 0, 10f);

        bool shouldDestroy = movementLogic.ShouldDestroy(new Vector3(20f, 0f, 0f));

        Assert.IsFalse(shouldDestroy);
    }
}