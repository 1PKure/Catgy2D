using NUnit.Framework;

public class GameStateModelTests
{
    [Test]
    public void Constructor_ShouldStartInPlayingState()
    {
        GameStateModel gameStateModel = new GameStateModel();

        Assert.AreEqual(GameState.Playing, gameStateModel.CurrentState);
    }

    [Test]
    public void CanResetPlayer_ShouldReturnTrue_WhenStateIsPlaying()
    {
        GameStateModel gameStateModel = new GameStateModel();

        bool canReset = gameStateModel.CanResetPlayer();

        Assert.IsTrue(canReset);
    }

    [Test]
    public void CanResetPlayer_ShouldReturnFalse_WhenStateIsPaused()
    {
        GameStateModel gameStateModel = new GameStateModel();

        gameStateModel.SetPaused();

        bool canReset = gameStateModel.CanResetPlayer();

        Assert.IsFalse(canReset);
    }

    [Test]
    public void CanResetPlayer_ShouldReturnFalse_WhenStateIsFinished()
    {
        GameStateModel gameStateModel = new GameStateModel();

        gameStateModel.SetFinished();

        bool canReset = gameStateModel.CanResetPlayer();

        Assert.IsFalse(canReset);
    }

    [Test]
    public void SetPaused_ShouldChangeStateToPaused_WhenGameIsNotFinished()
    {
        GameStateModel gameStateModel = new GameStateModel();

        gameStateModel.SetPaused();

        Assert.AreEqual(GameState.Paused, gameStateModel.CurrentState);
    }

    [Test]
    public void SetPaused_ShouldNotChangeState_WhenGameIsFinished()
    {
        GameStateModel gameStateModel = new GameStateModel();

        gameStateModel.SetFinished();
        gameStateModel.SetPaused();

        Assert.AreEqual(GameState.Finished, gameStateModel.CurrentState);
    }

    [Test]
    public void CanWinGame_ShouldReturnTrue_WhenGameIsPlaying()
    {
        GameStateModel gameStateModel = new GameStateModel();

        bool canWin = gameStateModel.CanWinGame();

        Assert.IsTrue(canWin);
    }

    [Test]
    public void CanWinGame_ShouldReturnFalse_WhenGameIsFinished()
    {
        GameStateModel gameStateModel = new GameStateModel();

        gameStateModel.SetFinished();

        bool canWin = gameStateModel.CanWinGame();

        Assert.IsFalse(canWin);
    }
}