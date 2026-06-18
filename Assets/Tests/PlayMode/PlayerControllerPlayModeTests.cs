using NUnit.Framework;
using UnityEngine;

public class PlayerControllerPlayModeTests
{
    [Test]
    public void ResetPlayer_ShouldMovePlayerToStartPoint()
    {
        GameObject playerObject = new GameObject("Test Player");
        PlayerController playerController = playerObject.AddComponent<PlayerController>();

        GameObject startPointObject = new GameObject("Test Start Point");
        startPointObject.transform.position = new Vector3(2f, 3f, 0f);

        playerObject.transform.position = new Vector3(10f, 10f, 0f);

        playerController.SetTestReferences(startPointObject.transform);
        playerController.ResetPlayer();

        Assert.AreEqual(startPointObject.transform.position, playerObject.transform.position);

        Object.DestroyImmediate(playerObject);
        Object.DestroyImmediate(startPointObject);
    }
}