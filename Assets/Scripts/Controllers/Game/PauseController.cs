using UnityEngine;

public class PauseController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameController gameController;

    private bool isPaused;

    private void Start()
    {
        ResumeGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
            return;
        }

        PauseGame();
    }

    public void PauseGame()
    {
        if (gameController != null && gameController.CurrentState == GameState.Finished)
        {
            return;
        }

        isPaused = true;
        Time.timeScale = 0f;

        if (gameController != null)
        {
            gameController.SetState(GameState.Paused);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        if (gameController != null && gameController.CurrentState == GameState.Finished)
        {
            return;
        }

        isPaused = false;
        Time.timeScale = 1f;

        if (gameController != null)
        {
            gameController.SetState(GameState.Playing);
        }

        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }
}