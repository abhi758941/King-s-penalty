using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacelPrefabs;
    [SerializeField] float obstacleSpawnTime = 2f;
    [SerializeField] Transform obstacleParent;
    [SerializeField] float spawnWidth;
    [SerializeField] float minimumObstacleSpawnTime = .5f;
    void Start()
    {
        StartCoroutine(SpawnObstacleRoutine());
    }

    public void DecreaseObstacleSpawnTime(float ammount)
    {
        obstacleSpawnTime -= ammount;
        if(obstacleSpawnTime<=minimumObstacleSpawnTime)
        {
            obstacleSpawnTime = minimumObstacleSpawnTime;
        }
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true)
        {
            GameObject obstaclePrefab = obstacelPrefabs[Random.Range(0, obstacelPrefabs.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), transform.position.y , transform.position.z);
            yield return new WaitForSeconds(obstacleSpawnTime);
            Instantiate(obstaclePrefab, spawnPosition ,Random.rotation, obstacleParent);
        }
    }
}
