using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController player;
    [SerializeField] private AudioManager audioManager;

    [Header("Scene Settings")]
    [SerializeField] private string winSceneName = "WinScene";
    [SerializeField] private float winDelay = 0.6f;

    private GameStateModel gameStateModel;

    public GameState CurrentState => gameStateModel.CurrentState;

    private void Awake()
    {
        gameStateModel = new GameStateModel();
    }

    private void Start()
    {
        SetState(GameState.Playing);
    }

    public void ResetPlayer()
    {
        if (!gameStateModel.CanResetPlayer())
        {
            return;
        }

        if (player != null)
        {
            player.ResetPlayer();
        }
    }

    public void WinGame()
    {
        if (!gameStateModel.CanWinGame())
        {
            return;
        }

        gameStateModel.SetFinished();

        if (player != null)
        {
            player.DisableMovement();
        }

        if (audioManager != null)
        {
            audioManager.PlayWinSound();
        }

        StartCoroutine(LoadWinSceneAfterDelay());
    }

    public void SetState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Playing:
                gameStateModel.SetPlaying();
                break;

            case GameState.Paused:
                gameStateModel.SetPaused();
                break;

            case GameState.Finished:
                gameStateModel.SetFinished();
                break;
        }
    }

    private IEnumerator LoadWinSceneAfterDelay()
    {
        yield return new WaitForSeconds(winDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(winSceneName);
    }
}