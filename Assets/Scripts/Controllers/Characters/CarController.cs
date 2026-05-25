using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed;
    private int direction;
    private float destroyPositionX;

    public void Initialize(float carSpeed, int moveDirection, float destroyX)
    {
        speed = carSpeed;
        direction = moveDirection;
        destroyPositionX = destroyX;

        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * direction;
        transform.localScale = scale;
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
}