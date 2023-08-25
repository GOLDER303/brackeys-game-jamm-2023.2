using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float minSpawnDelay = 4f;
    [SerializeField] private float maxSpawnDelay = 1f;
    [SerializeField] private float spawnDistance = 15f;
    [SerializeField] private DifficultyManager difficultyManager;

    private void Start()
    {
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }

    private IEnumerator SpawnEnemy(Enemy enemy)
    {
        while (true)
        {
            Vector2 spawnPointDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPointCoordinates = spawnPointDirection * spawnDistance + new Vector2(transform.position.x, transform.position.y);

            Enemy spawnedEnemy = Instantiate(enemy, spawnPointCoordinates, Quaternion.identity);

            spawnedEnemy.targetGameObject = playerGameObject;

            yield return new WaitForSeconds(minSpawnDelay + difficultyManager.CurrentDepthPercentage * (maxSpawnDelay - minSpawnDelay));
        }
    }
}
