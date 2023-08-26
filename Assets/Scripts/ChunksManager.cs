using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksManager : MonoBehaviour
{
    [SerializeField] private Chunk chunkPrefab;
    [SerializeField] private int chunkSize = 15;
    [SerializeField] private int loadDistance = 3;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private ResourceManager resourceManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private DifficultyManager difficultyManager;

    public float ChunkSize => chunkSize;

    private Chunk[] chunks;
    private Vector3 prevPlayerPosition;

    private void Start()
    {
        chunks = new Chunk[(loadDistance * 2 + 1) * (loadDistance * 2 + 1)];
        prevPlayerPosition = playerTransform.position;

        SpawnInitialChunks();
    }

    private void Update()
    {

        if (playerTransform.position != prevPlayerPosition)
        {
            UpdateChunks();
            prevPlayerPosition = playerTransform.position;
        }
    }

    private void SpawnInitialChunks()
    {
        int i = 0;
        for (int xOffset = -loadDistance; xOffset <= loadDistance; xOffset++)
        {
            for (int yOffset = -loadDistance; yOffset <= loadDistance; yOffset++)
            {
                Vector2 chunkCoordinates = new Vector2(xOffset, yOffset);

                Chunk chunk = Instantiate(chunkPrefab, chunkCoordinates * chunkSize, Quaternion.identity, transform);
                chunk.resourceManager = resourceManager;
                chunk.gameManager = gameManager;
                chunk.difficultyManager = difficultyManager;
                chunk.chunkSize = chunkSize;

                chunks[i] = chunk;
                i++;
            }
        }
    }

    private void UpdateChunks()
    {
        foreach (Chunk chunk in chunks)
        {
            Vector2 distanceFromPlayer = chunk.transform.position - playerTransform.position;

            if (Mathf.Abs(distanceFromPlayer.x) > chunkSize * (loadDistance + 1))
            {
                if (playerTransform.position.x < prevPlayerPosition.x)
                {
                    chunk.transform.position -= new Vector3((loadDistance * 2 + 1) * chunkSize, 0f, 0f);
                }
                else if (playerTransform.position.x > prevPlayerPosition.x)
                {
                    chunk.transform.position += new Vector3((loadDistance * 2 + 1) * chunkSize, 0f, 0f);
                }
            }
            else if (Mathf.Abs(distanceFromPlayer.y) > chunkSize * (loadDistance + 1))
            {
                if (playerTransform.position.y < prevPlayerPosition.y)
                {
                    chunk.transform.position -= new Vector3(0f, (loadDistance * 2 + 1) * chunkSize, 0f);
                }
                else if (playerTransform.position.y > prevPlayerPosition.y)
                {
                    chunk.transform.position += new Vector3(0f, (loadDistance * 2 + 1) * chunkSize, 0f);
                }
            }
        }
    }
}
