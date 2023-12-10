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
    private Coroutine spawnCoroutine; // Declare a variable to store the reference to the coroutine

    void Start()
    {
        objectPools = GetComponentsInChildren<ObjectPoolScript>();

        if (GameplayManager.instance.isPlaying)
        {
            // Start the coroutine and store the reference
            spawnCoroutine = StartCoroutine(SpawnObjectsWithDelay());
        }
    }

    void Update()
    {
        // Check if the gameplay state has changed
        if (GameplayManager.instance.isPlaying && spawnCoroutine == null)
        {
            // Start the coroutine if it hasn't been started
            spawnCoroutine = StartCoroutine(SpawnObjectsWithDelay());
        }
        else if (!GameplayManager.instance.isPlaying && spawnCoroutine != null)
        {
            // Stop the coroutine if it's running
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null; // Reset the reference
        }
    }

    IEnumerator SpawnObjectsWithDelay()
    {
        // Check if gameplay is currently active
        while (GameplayManager.instance.isPlaying)
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
                spawnDelay = Mathf.Max(0.5f, spawnDelay - 0.75f);
                currentWave++;
            }

            if (currentWave % 4 == 0)
            {
                spawnDelay = Mathf.Max(12f, spawnDelay - 1f);
            }

            lastSpawnPointIndex = -1; // Reset the last spawned spawn point index
        }

        yield return null; // Use yield return null to allow the while loop to check the condition in the next frame
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
                        enemy.moveSpeed = Mathf.Max(7.5f, enemy.moveSpeed + 0.25f);
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
