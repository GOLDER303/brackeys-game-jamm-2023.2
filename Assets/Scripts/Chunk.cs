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
    public GameManager gameManager { set; private get; }
    public DifficultyManager difficultyManager { set; private get; }
    public float chunkSize { set; private get; }

    private Vector3 prevPosition;
    private GameObject[] currentResources;
    private float maxDepth;
    private Sprite defaultSprite;

    private void Start()
    {
        maxDepth = gameManager.MaxDepth;
        defaultSprite = backgroundSpriteRenderer.sprite;
        currentResources = new GameObject[resourceManager.MaxAmountOfResources];
    }

    private void Update()
    {
        backgroundSpriteRenderer.color = Color.Lerp(surfaceBackgroundColor, maxDepthBackgroundColor, difficultyManager.CurrentDepthPercentage);

        if (transform.position != prevPosition)
        {
            UpdateResources();
            prevPosition = transform.position;

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
            else if (backgroundSpriteRenderer.sprite != defaultSprite)
            {
                backgroundSpriteRenderer.sprite = defaultSprite;
            }
        }
    }

    public void UpdateResources()
    {
        int i = 0;

        for (i = 0; i < currentResources.GetLength(0); i++)
        {
            Destroy(currentResources[i]);
        }

        Vector3[] newResourcesPositions = resourceManager.GetResourcesPositions(transform.position);

        i = 0;

        foreach (Vector3 resourcePosition in newResourcesPositions)
        {
            if (resourcePosition == Vector3.zero)
            {
                continue;
            }

            GameObject spawnedResource = Instantiate(resourceManager.GetResourcePrefab(transform.position), resourcePosition, Quaternion.identity, transform);

            currentResources[i] = spawnedResource;
            i++;
        }
    }
}
