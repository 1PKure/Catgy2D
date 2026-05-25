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

    private GameState currentState = GameState.Playing;

    public GameState CurrentState => currentState;

    private void Start()
    {
        SetState(GameState.Playing);
    }

    public void ResetPlayer()
    {
        if (currentState != GameState.Playing)
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
        if (currentState == GameState.Finished)
        {
            return;
        }

        SetState(GameState.Finished);

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
        currentState = newState;
    }

    private IEnumerator LoadWinSceneAfterDelay()
    {
        yield return new WaitForSeconds(winDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(winSceneName);
    }
}