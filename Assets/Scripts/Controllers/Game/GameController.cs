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

    private bool gameFinished;

    public void ResetPlayer()
    {
        if (gameFinished)
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
        if (gameFinished)
        {
            return;
        }

        gameFinished = true;

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

    private IEnumerator LoadWinSceneAfterDelay()
    {
        yield return new WaitForSeconds(winDelay);

        Time.timeScale = 1f;
        SceneManager.LoadScene(winSceneName);
    }
}