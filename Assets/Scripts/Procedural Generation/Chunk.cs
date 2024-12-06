using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject CoinPrefab;
    [Header("Values")]
    [SerializeField] float[] lanes = {-5f , 0f , 5f};
    [SerializeField] float spawnApleChance = 0.3f;
    [SerializeField] float spawnCoinChance = 0.5f;
    [SerializeField] float coinSpawnDistance = 2f;
    List<int> availableLane = new List<int>{0,1,2};
    LevelGenerator levelGenerator;
    ScoreManager scoreManager;
    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoins();
    }
    public void Init(LevelGenerator levelGenerator , ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }
    
    void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0 , lanes.Length);
        for(int i = 0 ; i < fencesToSpawn ; i++)
        {
            if (availableLane.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }

    }


    void SpawnApple()
        {
            if (Random.value > spawnApleChance || availableLane.Count <=0) return;
            
            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
            newApple.Init(levelGenerator);
        }
    void SpawnCoins()
    {
        if (Random.value > spawnCoinChance || availableLane.Count <=0) return;
        int selectedLane = SelectLane();
        int maxCoinsToSpawn = 5+1;    
        int coinsToSpawn =Random.Range(1,maxCoinsToSpawn);
        for (int i = 0 ; i < coinsToSpawn ; i++)
        {
            float spawnPosZ = transform.position.z + (i*coinSpawnDistance);
            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, spawnPosZ);
            Coins newCoin = Instantiate(CoinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coins>();
            newCoin.Init(scoreManager);
        }
    }
    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLane.Count);
        int selectedLane = availableLane[randomLaneIndex];
        availableLane.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
