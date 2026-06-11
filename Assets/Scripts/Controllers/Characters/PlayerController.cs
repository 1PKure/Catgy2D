using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float laneDistance = 2f;
    [SerializeField] private int minLane = 0;
    [SerializeField] private int maxLane = 4;

    [Header("References")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private PlayerView playerView;

    private PlayerModel playerModel;
    private PlayerMovementLogic movementLogic;

    private bool canMove = true;

    private void Awake()
    {
        playerModel = new PlayerModel(minLane, maxLane);
    }

    private void Start()
    {
        if (startPoint != null)
        {
            movementLogic = new PlayerMovementLogic(laneDistance, startPoint.position);
        }

        ResetPlayer();
    }

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveToLane(playerModel.CurrentLane + 1, 1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToLane(playerModel.CurrentLane - 1, -1);
        }
    }

    private void MoveToLane(int targetLane, int moveDirection)
    {
        if (!playerModel.TrySetCurrentLane(targetLane))
        {
            return;
        }

        if (movementLogic != null)
        {
            transform.position = movementLogic.GetPositionForLane(playerModel.CurrentLane);
        }

        PlayMoveFeedback(moveDirection);
    }

    private void PlayMoveFeedback(int moveDirection)
    {
        if (audioManager != null)
        {
            audioManager.PlayMoveSound();
        }

        if (playerView != null)
        {
            playerView.PlayMoveAnimation(moveDirection);
        }
    }

    public void ResetPlayer()
    {
        playerModel.Reset();

        if (movementLogic != null)
        {
            transform.position = movementLogic.GetPositionForLane(playerModel.CurrentLane);
        }
        else if (startPoint != null)
        {
            transform.position = startPoint.position;
        }

        canMove = true;

        if (playerView != null)
        {
            playerView.PlayIdleAnimation();
        }
    }

    public void DisableMovement()
    {
        canMove = false;

        if (playerView != null)
        {
            playerView.PlayIdleAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
            if (audioManager != null)
            {
                audioManager.PlayCrashSound();
            }

            if (gameController != null)
            {
                gameController.ResetPlayer();
            }

            return;
        }

        if (other.CompareTag("Goal"))
        {
            if (gameController != null)
            {
                gameController.WinGame();
            }
        }
    }
}