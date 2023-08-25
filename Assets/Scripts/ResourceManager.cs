using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] resourcesPrefabs;

    [SerializeField] private int minAmountOfResources = 1;
    [SerializeField] private int maxAmountOfResources = 5;
    [SerializeField] private ChunksManager chunksManager;

    private float chunkSize;

    private void Start()
    {
        chunkSize = chunksManager.ChunkSize;
    }

    public Vector3[] GetResourcesPositions(Vector3 chunkCoordinates)
    {
        Random.InitState(Mathf.FloorToInt(chunkCoordinates.x) ^ Mathf.FloorToInt(chunkCoordinates.y));

        int resourcesAmount = Random.Range(minAmountOfResources, maxAmountOfResources);

        Vector3[] resourcesPositions = new Vector3[resourcesAmount];

        Vector3 spawnAreaMin = chunkCoordinates - new Vector3(chunkSize / 2, chunkSize / 2, 0f);
        Vector3 spawnAreaMax = chunkCoordinates + new Vector3(chunkSize / 2, chunkSize / 2, 0f);

        for (int i = 0; i < resourcesAmount; i++)
        {
            //TODO: keep track of already collected resources
            resourcesPositions[i] = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);
        }

        return resourcesPositions;
    }

    public GameObject GetRandomResourcePrefab()
    {
        return resourcesPrefabs[Random.Range(0, resourcesPrefabs.GetLength(0))];
    }
}
