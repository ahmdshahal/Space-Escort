using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public ObjectPoolScript[] objectPools;

    public int totalSpawn;
    public float spawnDelay = 2f;
    private int spawnedCount = 0;

    private int currentWave = 0;
    public float delayWave;

    private int lastSpawnPointIndex = -1; // Track the last spawned spawn point

    void Start()
    {
        objectPools = GetComponentsInChildren<ObjectPoolScript>();
        StartCoroutine(SpawnObjectsWithDelay());
    }

    IEnumerator SpawnObjectsWithDelay()
    {
        if (spawnPoints.Length == 0 || objectPools.Length == 0)
        {
            Debug.LogError("Spawn points or objects to spawn are not set!");
            yield break;
        }

        while (spawnedCount < totalSpawn)
        {
            SpawnObject();

            spawnedCount++;

            yield return new WaitForSeconds(spawnDelay);
        }

        Debug.Log("Spawn complete!");

        // Restart
        yield return new WaitForSeconds(delayWave);

        spawnedCount = 0;

        if (currentWave % 3 == 0)
        {
            spawnDelay = Mathf.Max(1f, spawnDelay - 0.5f);

            currentWave++;
        }

        lastSpawnPointIndex = -1; // Reset the last spawned spawn point index

        StartCoroutine(SpawnObjectsWithDelay());
    }

    private void SpawnObject()
    {
        int randomPool;

        if (currentWave <= 5)
        {
            randomPool = Random.Range(0, 2);
        }
        else
        {
            randomPool = Random.Range(0, objectPools.Length);
        }

        int randomPosition = GetRandomSpawnPointIndex();

        if (objectPools != null && objectPools.Length > randomPool && spawnPoints != null && spawnPoints.Length > randomPosition)
        {
            GameObject obj = objectPools[randomPool]?.GetPooledObject();

            if (obj != null)
            {
                obj.transform.position = spawnPoints[randomPosition].position;
                obj.SetActive(true);

                lastSpawnPointIndex = randomPosition; 

                if (currentWave % 3 == 0)
                {
                    Enemy enemy = obj.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.moveSpeed = Mathf.Max(7f, enemy.moveSpeed + 0.2f);
                    }

                    //EnemyShip enemyShip = obj.GetComponent<EnemyShip>();
                    //if (enemyShip != null)
                    //{
                    //    enemyShip.moveSpeed = Mathf.Max(7f, enemyShip.moveSpeed + 0.2f);
                    //}
                }
            }
        }
    }

    private int GetRandomSpawnPointIndex()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        while (randomIndex == lastSpawnPointIndex)
        {
            randomIndex = Random.Range(0, spawnPoints.Length);
        }
        return randomIndex;
    }
}
