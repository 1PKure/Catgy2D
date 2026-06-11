public class GameStateModel
{
    public GameState CurrentState { get; private set; }

    public GameStateModel()
    {
        CurrentState = GameState.Playing;
    }

    public bool CanResetPlayer()
    {
        return CurrentState == GameState.Playing;
    }

    public bool CanWinGame()
    {
        return CurrentState != GameState.Finished;
    }

    public void SetPlaying()
    {
        CurrentState = GameState.Playing;
    }

    public void SetPaused()
    {
        if (CurrentState == GameState.Finished)
        {
            return;
        }

        CurrentState = GameState.Paused;
    }

    public void SetFinished()
    {
        CurrentState = GameState.Finished;
    }
}