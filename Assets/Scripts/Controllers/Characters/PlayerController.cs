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

    private int currentLane;
    private bool canMove = true;

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
            MoveToLane(currentLane + 1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveToLane(currentLane - 1);
        }
    }

    private void MoveToLane(int targetLane)
    {
        if (targetLane < minLane || targetLane > maxLane)
        {
            return;
        }

        currentLane = targetLane;

        Vector3 newPosition = transform.position;
        newPosition.y = startPoint.position.y + currentLane * laneDistance;

        transform.position = newPosition;
    }

    public void ResetPlayer()
    {
        currentLane = minLane;

        if (startPoint != null)
        {
            transform.position = startPoint.position;
        }

        canMove = true;
    }

    public void DisableMovement()
    {
        canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Car"))
        {
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