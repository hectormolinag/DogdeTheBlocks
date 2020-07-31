using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    [SerializeField] Transform[] spawnPoints;
    [Header("Block Prefab")]
    [SerializeField] GameObject blockPrefab;
    [SerializeField] GameObject colliderPrefab;

    [Header("Time")]
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] float timeToSpawn = 2f;

	void Update () 
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }
	
    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            else
                Instantiate(colliderPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}
