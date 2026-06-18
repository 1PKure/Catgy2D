using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CarView carView;

    private CarMovementLogic movementLogic;

    private void Awake()
    {
        if (carView != null)
        {
            carView.ApplySortingOrder();
        }
    }

    public void Initialize(LaneData laneData)
    {
        if (laneData == null)
        {
            return;
        }

        movementLogic = new CarMovementLogic(
            laneData.CarSpeed,
            laneData.Direction,
            laneData.DestroyPositionX
        );

        if (carView != null)
        {
            carView.SetSprite(laneData.CarSprite);
            carView.SetDirection(laneData.Direction);
            carView.ApplySortingOrder();
        }
    }

    private void Update()
    {
        if (movementLogic == null)
        {
            return;
        }

        Move();
        CheckDestroyCondition();
    }

    private void Move()
    {
        transform.position = movementLogic.GetNextPosition(transform.position, Time.deltaTime);
    }

    private void CheckDestroyCondition()
    {
        if (movementLogic.ShouldDestroy(transform.position))
        {
            Destroy(gameObject);
        }
    }

    #if UNITY_EDITOR
    public void TickForTests(float deltaTime)
    {
        if (movementLogic == null)
        {
            return;
        }

        transform.position = movementLogic.GetNextPosition(transform.position, deltaTime);
    }
#endif

}