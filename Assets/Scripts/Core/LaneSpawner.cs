using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform spawnPoint;

    [Header("Lane Model")]
    [SerializeField] private LaneData laneData;

    private SpawnTimer spawnTimer;

    private void Awake()
    {
        if (laneData != null)
        {
            spawnTimer = new SpawnTimer(laneData.SpawnInterval);
        }

        SpawnCar();
    }

    private void Update()
    {
        UpdateSpawnTimer();
    }

    private void UpdateSpawnTimer()
    {
        if (spawnTimer == null)
        {
            return;
        }

        if (spawnTimer.Tick(Time.deltaTime))
        {
            SpawnCar();
        }
    }

    private void SpawnCar()
    {
        if (carPrefab == null || spawnPoint == null || laneData == null)
        {
            return;
        }

        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);

        CarController carController = newCar.GetComponent<CarController>();

        if (carController != null)
        {
            carController.Initialize(laneData);
        }
    }
}