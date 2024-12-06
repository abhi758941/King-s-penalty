using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject checkpointChunkPrefab;
    [SerializeField] int StartingChunkAmmount;
    [SerializeField] Transform chunkParent;
    [SerializeField] CameraController cameraController;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [Tooltip("Do not change chunk length")]
    [SerializeField] float chunkLength  = 10;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 8f;
    [SerializeField] float maxMoveSpeed = 20f;
    [SerializeField] float minGravityZ = -9.8f;
    [SerializeField] int checkpointInterval = 8;
    int chunksSpawned = 0;
    
    List<GameObject> chunks = new List<GameObject>();
     private void Start()
    {
        SpawnStartingChunks();

    }
    private void Update() 
    {
        MoveChunks();
    }

    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMovSpeed = moveSpeed+speedAmount;
        newMovSpeed = Mathf.Clamp(newMovSpeed, minMoveSpeed , maxMoveSpeed);
        if (moveSpeed != newMovSpeed)
        {
            moveSpeed = newMovSpeed;
        }
        float newGravity = Physics.gravity.z - speedAmount;
        if (newGravity > minGravityZ)
        {
            newGravity = minGravityZ;
        }
        Physics.gravity = new Vector3(Physics.gravity.x , Physics.gravity.y ,newGravity );
        
        cameraController.ChangeCameraFOV(speedAmount);
        
    }
    private void SpawnStartingChunks()
    {
        for (int i = 0; i < StartingChunkAmmount; i++)
        {
            SpawnChunkSingular();
        }
    }

    private void SpawnChunkSingular()
    {
        float spawnPositionZ = SetZPosition();
        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);
        GameObject chunkToSpawn = ChooseChunktoSpawn();
        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);
        chunksSpawned++;
    }

    private GameObject ChooseChunktoSpawn()
    {
        GameObject chunkToSpawn;
        if (chunksSpawned % checkpointInterval == 0 && chunksSpawned != 0)
        {
            chunksSpawned = 0;
            chunkToSpawn = checkpointChunkPrefab;
        }
        else
        {
            chunkToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        }

        return chunkToSpawn;
    }

    private float SetZPosition()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count-1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }
    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));
            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunkSingular();
            }
        }
        
    }
    
}
