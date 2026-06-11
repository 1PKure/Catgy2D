public class SpawnTimer
{
    private readonly float interval;
    private float currentTime;

    public SpawnTimer(float interval)
    {
        this.interval = interval;
        currentTime = 0f;
    }

    public bool Tick(float deltaTime)
    {
        currentTime += deltaTime;

        if (currentTime < interval)
        {
            return false;
        }

        currentTime = 0f;
        return true;
    }

    public void Reset()
    {
        currentTime = 0f;
    }

    public float CurrentTime => currentTime;
    public float Interval => interval;
}