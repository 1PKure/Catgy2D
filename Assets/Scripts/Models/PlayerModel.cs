[System.Serializable]
public class PlayerModel
{
    public int CurrentLane { get; private set; }
    public int MinLane { get; private set; }
    public int MaxLane { get; private set; }

    public PlayerModel(int minLane, int maxLane)
    {
        MinLane = minLane;
        MaxLane = maxLane;
        CurrentLane = minLane;
    }

    public bool CanMoveToLane(int targetLane)
    {
        return targetLane >= MinLane && targetLane <= MaxLane;
    }

    public void SetCurrentLane(int lane)
    {
        CurrentLane = lane;
    }

    public void Reset()
    {
        CurrentLane = MinLane;
    }
}