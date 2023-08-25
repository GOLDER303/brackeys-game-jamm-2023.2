using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private Color surfaceBackgroundColor;
    [SerializeField] private Color maxDepthBackgroundColor;

    public ResourceManager resourceManager { set; private get; }
    public DifficultyManager difficultyManager { set; private get; }

    private Vector3 prevPosition;
    private readonly List<GameObject> currentResources = new();

    private void Update()
    {
        backgroundSpriteRenderer.color = Color.Lerp(surfaceBackgroundColor, maxDepthBackgroundColor, difficultyManager.CurrentDepthPercentage);

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
            if (resourcePosition == Vector3.zero)
            {
                continue;
            }

            GameObject spawnedResource = Instantiate(resourceManager.GetResourcePrefab(), resourcePosition, Quaternion.identity, transform);
            currentResources.Add(spawnedResource);
        }
    }
}
