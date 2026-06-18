using NUnit.Framework;
using UnityEngine;

public class PlayerViewPlayModeTests
{
    [Test]
    public void PlayIdleAnimation_ShouldPlayIdleState()
    {
        GameObject playerObject = new GameObject("Test Player View");
        PlayerView playerView = playerObject.AddComponent<PlayerView>();

        playerView.PlayIdleAnimation();

        Assert.AreEqual("Cat_Idle", playerView.LastPlayedState);

        Object.DestroyImmediate(playerObject);
    }

    [Test]
    public void PlayMoveAnimation_ShouldPlayUpWalkState_WhenDirectionIsPositive()
    {
        GameObject playerObject = new GameObject("Test Player View");
        PlayerView playerView = playerObject.AddComponent<PlayerView>();

        playerView.PlayMoveAnimation(1);

        Assert.AreEqual("Cat_BackWalk", playerView.LastPlayedState);

        Object.DestroyImmediate(playerObject);
    }

    [Test]
    public void PlayMoveAnimation_ShouldPlayDownWalkState_WhenDirectionIsNegative()
    {
        GameObject playerObject = new GameObject("Test Player View");
        PlayerView playerView = playerObject.AddComponent<PlayerView>();

        playerView.PlayMoveAnimation(-1);

        Assert.AreEqual("Cat_FrontWalk", playerView.LastPlayedState);

        Object.DestroyImmediate(playerObject);
    }

    [Test]
    public void PlayMoveAnimation_ShouldPlayIdleState_WhenDirectionIsZero()
    {
        GameObject playerObject = new GameObject("Test Player View");
        PlayerView playerView = playerObject.AddComponent<PlayerView>();

        playerView.PlayMoveAnimation(0);

        Assert.AreEqual("Cat_Idle", playerView.LastPlayedState);

        Object.DestroyImmediate(playerObject);
    }
}