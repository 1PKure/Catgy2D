using NUnit.Framework;

public class SpawnTimerTests
{
    [Test]
    public void Tick_ShouldReturnFalse_WhenIntervalHasNotBeenReached()
    {
        SpawnTimer spawnTimer = new SpawnTimer(2f);

        bool result = spawnTimer.Tick(1f);

        Assert.IsFalse(result);
    }

    [Test]
    public void Tick_ShouldReturnTrue_WhenIntervalHasBeenReached()
    {
        SpawnTimer spawnTimer = new SpawnTimer(2f);

        bool result = spawnTimer.Tick(2f);

        Assert.IsTrue(result);
    }

    [Test]
    public void Tick_ShouldAccumulateDeltaTime()
    {
        SpawnTimer spawnTimer = new SpawnTimer(2f);

        bool firstTick = spawnTimer.Tick(1f);
        bool secondTick = spawnTimer.Tick(1f);

        Assert.IsFalse(firstTick);
        Assert.IsTrue(secondTick);
    }

    [Test]
    public void Tick_ShouldResetCurrentTime_WhenIntervalHasBeenReached()
    {
        SpawnTimer spawnTimer = new SpawnTimer(2f);

        spawnTimer.Tick(2f);

        Assert.AreEqual(0f, spawnTimer.CurrentTime);
    }

    [Test]
    public void Reset_ShouldSetCurrentTimeToZero()
    {
        SpawnTimer spawnTimer = new SpawnTimer(2f);
        spawnTimer.Tick(1f);

        spawnTimer.Reset();

        Assert.AreEqual(0f, spawnTimer.CurrentTime);
    }
}