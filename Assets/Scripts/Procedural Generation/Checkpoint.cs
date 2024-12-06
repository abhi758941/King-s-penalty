using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float timeToIncrease = 5f;
    [SerializeField] float timeToDecreaseSpawn = .1f;
    const string PlayerString = "Player";
    GameManager gameManager;
    ObstacleSpawner obstacleSpawner;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag(PlayerString))
        {
            gameManager.IncreaseTime(timeToIncrease);
            obstacleSpawner.DecreaseObstacleSpawnTime(timeToDecreaseSpawn);
        }    
    }
}
