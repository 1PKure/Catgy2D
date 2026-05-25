using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CarView carView;

    private float speed;
    private int direction;
    private float destroyPositionX;

    private void Awake()
    {
        if (carView != null)
        {
            carView.ApplySortingOrder();
        }
    }

    public void Initialize(LaneData laneData)
    {
        speed = laneData.CarSpeed;
        direction = laneData.Direction;
        destroyPositionX = laneData.DestroyPositionX;

        if (carView != null)
        {
            carView.SetSprite(laneData.CarSprite);
            carView.SetDirection(direction);
            carView.ApplySortingOrder();
        }
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