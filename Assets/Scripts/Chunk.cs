using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public ResourceManager resourceManager { set; private get; }

    private Vector3 prevPosition;
    private readonly List<GameObject> currentResources = new();

    private void Update()
    {
        if (transform.position != prevPosition)
        {
            UpdateResources();
            prevPosition = transform.position;
        }
    }

    private void UpdateResources()
    {
        for (int i = 0; i < currentResources.Count; i++)
        {
            Destroy(currentResources[i]);
            currentResources[i] = null;
        }

        Vector3[] newResourcesPositions = resourceManager.GetResourcesPositions(transform.position);

        foreach (Vector3 resourcePosition in newResourcesPositions)
        {
            GameObject spawnedResource = Instantiate(resourceManager.GetRandomResourcePrefab(), resourcePosition, Quaternion.identity, transform);
            currentResources.Add(spawnedResource);
        }
    }
}
