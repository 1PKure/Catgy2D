using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;

    private float speed;
    private int direction;
    private float destroyPositionX;

    public void Initialize(float carSpeed, int moveDirection, float destroyX, Sprite carSprite)
    {
        speed = carSpeed;
        direction = moveDirection;
        destroyPositionX = destroyX;

        SetSprite(carSprite);
        UpdateCarRotation();
    }

    private void Update()
    {
        Move();
        CheckDestroyCondition();
    }

    private void Move()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
    }

    private void CheckDestroyCondition()
    {
        if (direction > 0 && transform.position.x >= destroyPositionX)
        {
            Destroy(gameObject);
        }

        if (direction < 0 && transform.position.x <= destroyPositionX)
        {
            Destroy(gameObject);
        }
    }

    private void SetSprite(Sprite carSprite)
    {
        if (spriteRenderer != null && carSprite != null)
        {
            spriteRenderer.sprite = carSprite;
        }
    }

    private void UpdateCarRotation()
    {
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
    }
}