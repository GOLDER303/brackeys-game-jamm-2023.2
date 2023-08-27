using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float initialDelay = 4f;
    [SerializeField] private float minSpawnDelay = 4f;
    [SerializeField] private float maxSpawnDelay = 1f;
    [SerializeField] private float spawnDistance = 15f;
    [SerializeField] private DifficultyManager difficultyManager;
    [SerializeField] private int amountOfEnemyTypePerDepthLevel = 2;

    private void Start()
    {
        StartCoroutine(StartSpawningEnemies());
    }

    private IEnumerator StartSpawningEnemies()
    {
        yield return new WaitForSeconds(initialDelay);
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector2 spawnPointDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPointCoordinates = spawnPointDirection * spawnDistance + new Vector2(transform.position.x, transform.position.y);

            Enemy enemyPrefab = GetEnemyPrefab();

            Enemy spawnedEnemy = Instantiate(enemyPrefab, spawnPointCoordinates, Quaternion.identity);

            spawnedEnemy.targetGameObject = playerGameObject;

            yield return new WaitForSeconds(minSpawnDelay + difficultyManager.CurrentDepthPercentage * (maxSpawnDelay - minSpawnDelay));
        }
    }

    private Enemy GetEnemyPrefab()
    {
        int minResourcePrefabIndex = (int)Mathf.Floor(enemyPrefabs.GetLength(0) * difficultyManager.CurrentDepthPercentage);
        int maxResourcePrefabIndex = minResourcePrefabIndex + amountOfEnemyTypePerDepthLevel;

        if (maxResourcePrefabIndex > enemyPrefabs.GetLength(0))
        {
            maxResourcePrefabIndex = enemyPrefabs.GetLength(0);
        }

        return enemyPrefabs[Random.Range(minResourcePrefabIndex, maxResourcePrefabIndex)];
    }
}
