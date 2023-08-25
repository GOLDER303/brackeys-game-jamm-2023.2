using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSpriteRenderer;
    [SerializeField] private Color surfaceBackgroundColor;
    [SerializeField] private Color maxDepthBackgroundColor;
    [SerializeField] private Sprite oceanFloorSprite;
    [SerializeField] private Sprite oceanUnderFloorSprite;

    public ResourceManager resourceManager { set; private get; }
    public DifficultyManager difficultyManager { set; private get; }
    public float chunkSize { set; private get; }

    private Vector3 prevPosition;
    private readonly List<GameObject> currentResources = new();
    private float maxDepth;

    private void Start()
    {
        maxDepth = difficultyManager.MaxDepth;
    }

    private void Update()
    {
        backgroundSpriteRenderer.color = Color.Lerp(surfaceBackgroundColor, maxDepthBackgroundColor, difficultyManager.CurrentDepthPercentage);

        if (transform.position != prevPosition)
        {
            UpdateResources();
            prevPosition = transform.position;
        }

        float currentDepth = -transform.position.y;

        if (currentDepth >= maxDepth)
        {
            if (currentDepth - maxDepth >= chunkSize)
            {
                backgroundSpriteRenderer.sprite = oceanUnderFloorSprite;
            }
            else
            {
                backgroundSpriteRenderer.sprite = oceanFloorSprite;
            }
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
