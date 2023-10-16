using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnIntervalInSeconds = 1f;
    public float initalSpanningAfterSeconds = 1f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", initalSpanningAfterSeconds, spawnIntervalInSeconds);
    }

    private void SpawnEnemy()
    {
        float randomFactor = Random.value;

        // spawn enemies 30% of the time
        if (randomFactor < 0.3f)
        {
            int randomEnemySelector = Random.Range(0, enemies.Length);
            GameObject currentEnemy = enemies[randomEnemySelector];
            Instantiate(currentEnemy, transform.position, Quaternion.identity);
        }
    }
}
