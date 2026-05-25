using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController player;

    [Header("Scene Settings")]
    [SerializeField] private string winSceneName = "WinScene";

    public void ResetPlayer()
    {
        if (player != null)
        {
            player.ResetPlayer();
        }
    }

    public void WinGame()
    {
        if (player != null)
        {
            player.DisableMovement();
        }

        SceneManager.LoadScene(winSceneName);
    }
}