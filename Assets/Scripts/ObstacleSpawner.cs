using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject groundObstaclePrefab;
    public GameObject airObstaclePrefab;
    public GameObject scoreItemPrefab;

    public float minSpawnTime = 1.5f;
    public float maxSpawnTime = 3f;

    private float timer;
    private float nextSpawnTime;

    private void Start()
    {
        SetNextSpawnTime();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= nextSpawnTime)
        {
            SpawnObject();

            timer = 0f;
            SetNextSpawnTime();
        }
    }

    private void SpawnObject()
    {
        int randomObject = Random.Range(0, 3);

        if (randomObject == 0)
        {
            Instantiate(
                groundObstaclePrefab,
                transform.position,
                Quaternion.identity
            );
        }
        else if (randomObject == 1)
        {
            Vector3 airPosition = transform.position;
            airPosition.y = 0f;

            Instantiate(
                airObstaclePrefab,
                airPosition,
                Quaternion.identity
            );
        }
        else
        {
            Vector3 scorePosition = transform.position;
            scorePosition.y = Random.Range(-0.8f, 1.2f);

            Instantiate(
                scoreItemPrefab,
                scorePosition,
                Quaternion.identity
            );
        }
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
}