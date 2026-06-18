using NUnit.Framework;
using UnityEngine;

public class CarControllerPlayModeTests
{
    [Test]
    public void CarController_ShouldMoveCar_WhenTickForTestsIsCalled()
    {
        GameObject carObject = new GameObject("Test Car");
        CarController carController = carObject.AddComponent<CarController>();

        LaneData laneData = new LaneData
        {
            CarSpeed = 4f,
            Direction = 1,
            DestroyPositionX = 100f,
            SpawnInterval = 1f,
            CarSprite = null
        };

        Vector3 startPosition = carObject.transform.position;

        carController.Initialize(laneData);
        carController.TickForTests(0.5f);

        Assert.Greater(carObject.transform.position.x, startPosition.x);

        Object.DestroyImmediate(carObject);
    }
}