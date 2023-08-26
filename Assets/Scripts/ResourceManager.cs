using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private GameObject[] resourcesPrefabs;
    [SerializeField] private int minAmountOfResources = 1;
    [SerializeField] private int maxAmountOfResources = 5;
    [SerializeField] private ChunksManager chunksManager;
    [SerializeField] private DifficultyManager difficultyManager;
    [SerializeField] private int amountOfResourceTypePerDepthLevel;

    public int MaxAmountOfResources => maxAmountOfResources;

    private float chunkSize;
    private readonly HashSet<Vector3> collectedResourcesPosition = new();

    private void OnEnable()
    {
        PlayerController.OnResourceCollected += HandleResourceCollected;
    }

    private void OnDisable()
    {
        PlayerController.OnResourceCollected -= HandleResourceCollected;
    }

    private void Awake()
    {
        chunkSize = chunksManager.ChunkSize;
    }

    public Vector3[] GetResourcesPositions(Vector3 chunkCoordinates)
    {
        Random.InitState(Mathf.FloorToInt(chunkCoordinates.x) ^ Mathf.FloorToInt(chunkCoordinates.y));

        int resourcesAmount = Random.Range(minAmountOfResources, maxAmountOfResources + 1);

        Vector3[] resourcesPositions = new Vector3[resourcesAmount];

        Vector3 spawnAreaMin = chunkCoordinates - new Vector3(chunkSize / 2, chunkSize / 2, 0f);
        Vector3 spawnAreaMax = chunkCoordinates + new Vector3(chunkSize / 2, chunkSize / 2, 0f);

        for (int i = 0; i < resourcesAmount; i++)
        {
            Vector3 position = new Vector3(Random.Range(spawnAreaMin.x, spawnAreaMax.x), Random.Range(spawnAreaMin.y, spawnAreaMax.y), 0f);

            if (collectedResourcesPosition.Contains(position))
            {
                resourcesPositions[i] = Vector3.zero;
            }
            else
            {
                resourcesPositions[i] = position;
            }
        }

        return resourcesPositions;
    }

    public GameObject GetResourcePrefab()
    {
        int minResourcePrefabIndex = (int)Mathf.Floor(resourcesPrefabs.GetLength(0) * difficultyManager.CurrentDepthPercentage);
        int maxResourcePrefabIndex = minResourcePrefabIndex + amountOfResourceTypePerDepthLevel;

        if (maxResourcePrefabIndex > resourcesPrefabs.GetLength(0))
        {
            maxResourcePrefabIndex = resourcesPrefabs.GetLength(0);
        }

        return resourcesPrefabs[Random.Range(minResourcePrefabIndex, maxResourcePrefabIndex)];
    }

    private void HandleResourceCollected(Resource resource)
    {
        collectedResourcesPosition.Add(resource.transform.position);
    }
}
