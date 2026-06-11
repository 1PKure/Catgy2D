using UnityEngine;

public class CarMovementLogic
{
    private readonly float speed;
    private readonly int direction;
    private readonly float destroyPositionX;

    public CarMovementLogic(float speed, int direction, float destroyPositionX)
    {
        this.speed = speed;
        this.direction = direction;
        this.destroyPositionX = destroyPositionX;
    }

    public Vector3 GetNextPosition(Vector3 currentPosition, float deltaTime)
    {
        return currentPosition + Vector3.right * direction * speed * deltaTime;
    }

    public bool ShouldDestroy(Vector3 currentPosition)
    {
        if (direction > 0)
        {
            return currentPosition.x >= destroyPositionX;
        }

        if (direction < 0)
        {
            return currentPosition.x <= destroyPositionX;
        }

        return false;
    }
}