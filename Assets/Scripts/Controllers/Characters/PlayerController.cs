using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float laneDistance = 2f;
    [SerializeField] private int minLane = 0;
    [SerializeField] private int maxLane = 4;
    [SerializeField] private float moveAnimationDuration = 0.15f;

    [Header("References")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Animator animator;

    private int currentLane;
    private bool canMove = true;
    private Coroutine moveAnimationCoroutine;

    private void Start()
    {
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
            MoveToLane(currentLane + 1, 1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToLane(currentLane - 1, -1);
        }
    }

    private void MoveToLane(int targetLane, int moveDirection)
    {
        if (targetLane < minLane || targetLane > maxLane)
        {
            return;
        }

        currentLane = targetLane;

        Vector3 newPosition = transform.position;
        newPosition.y = startPoint.position.y + currentLane * laneDistance;

        transform.position = newPosition;

        PlayMoveFeedback(moveDirection);
    }

    private void PlayMoveFeedback(int moveDirection)
    {
        if (audioManager != null)
        {
            audioManager.PlayMoveSound();
        }

        if (moveAnimationCoroutine != null)
        {
            StopCoroutine(moveAnimationCoroutine);
        }

        moveAnimationCoroutine = StartCoroutine(PlayMoveAnimationBriefly(moveDirection));
    }

    private IEnumerator PlayMoveAnimationBriefly(int moveDirection)
    {
        SetMoveDirection(moveDirection);

        yield return new WaitForSeconds(moveAnimationDuration);

        SetMoveDirection(0);
    }

    private void SetMoveDirection(int moveDirection)
    {
        if (animator != null)
        {
            animator.SetInteger("MoveDirection", moveDirection);
        }
    }

    public void ResetPlayer()
    {
        currentLane = minLane;

        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }

        canMove = true;
        SetMoveDirection(0);
    }

    public void DisableMovement()
    {
        canMove = false;
        SetMoveDirection(0);
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