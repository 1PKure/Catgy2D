using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    [Header("Car Settings")]
    [SerializeField] private GameObject carPrefab;
    [SerializeField] private Sprite carSprite;
    [SerializeField] private Transform spawnPoint;

    [Header("Lane Settings")]
    [SerializeField] private float carSpeed = 4f;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int direction = 1;
    [SerializeField] private float destroyPositionX = 10f;

    private float spawnTimer;

    private void Update()
    {
        UpdateSpawnTimer();
    }

    private void UpdateSpawnTimer()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnCar();
            spawnTimer = 0f;
        }
    }

    private void SpawnCar()
    {
        if (carPrefab == null || spawnPoint == null)
        {
            return;
        }

        GameObject newCar = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);

        CarController carController = newCar.GetComponent<CarController>();

        if (carController != null)
        {
            carController.Initialize(carSpeed, direction, destroyPositionX, carSprite);
        }
    }
}