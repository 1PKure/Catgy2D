using UnityEngine;

public class PlayerMovementLogic
{
    private readonly float laneDistance;
    private readonly Vector3 startPosition;

    public PlayerMovementLogic(float laneDistance, Vector3 startPosition)
    {
        this.laneDistance = laneDistance;
        this.startPosition = startPosition;
    }

    public Vector3 GetPositionForLane(int lane)
    {
        return new Vector3(
            startPosition.x,
            startPosition.y + lane * laneDistance,
            startPosition.z
        );
    }
}