using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Transform spawnPoint;

    [Header("Lane Model")]
    [SerializeField] private LaneData laneData;

    private float spawnTimer;
    private void Awake()
    {
        SpawnCar();
        spawnTimer = 0f;
    }
    private void Update()
    {
        UpdateSpawnTimer();
    }

    private void UpdateSpawnTimer()
    {
        if (laneData == null)
        {
            return;
        }

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= laneData.SpawnInterval)
        {
            SpawnCar();
            spawnTimer = 0f;
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