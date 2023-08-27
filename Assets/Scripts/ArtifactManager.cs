using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactManager : MonoBehaviour
{
    public static Action<Transform> OnArtifactSpawn;

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float artifactSpawnDepth;
    [SerializeField] private GameObject artifactPrefab;
    [SerializeField] private int artifactSpawnMinDistance = 100;
    [SerializeField] private int artifactSpawnMaxDistance = 500;

    private bool artifactSpawned = false;


    private void Update()
    {
        if (!artifactSpawned && -playerGameObject.transform.position.y >= artifactSpawnDepth)
        {
            SpawnArtifact();
        }
    }

    private void SpawnArtifact()
    {
        int spawnXPosition = UnityEngine.Random.Range(artifactSpawnMinDistance, artifactSpawnMaxDistance + 1);

        spawnXPosition *= UnityEngine.Random.Range(0, 2) * 2 - 1;

        GameObject artifactGameObject = Instantiate(artifactPrefab, new Vector3(spawnXPosition, -artifactSpawnDepth, 0f), Quaternion.identity);

        OnArtifactSpawn?.Invoke(artifactGameObject.transform);

        artifactSpawned = true;
    }
}
