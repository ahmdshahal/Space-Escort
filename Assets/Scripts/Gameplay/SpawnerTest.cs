using UnityEngine;
using System.Collections;

public class SpawnerTest : MonoBehaviour
{
    public Transform[] spawnPoints;
    public ObjectPoolScript[] objectPools;

    public int totalSpawn;
    public float spawnDelay = 2f; 
    private int spawnedCount = 0;

    private int currentWave = 0;
    public float delayWave;

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

        if (currentWave % 5 == 0)
        {
            spawnDelay = Mathf.Max(2f, spawnDelay - 0.5f);

            currentWave++;
        }

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

        int randomPosition = Random.Range(0, spawnPoints.Length);

        if (objectPools != null && objectPools.Length > randomPool)
        {
            GameObject obj = objectPools[randomPool].GetPooledObject();

            if (obj == null) return;

            obj.transform.position = spawnPoints[randomPosition].position;
            obj.SetActive(true);

            if(currentWave % 5 == 0)
            {
                obj.gameObject.GetComponent<ObstacleBehav>().moveSpeed = Mathf.Max(1f, obj.gameObject.GetComponent<ObstacleBehav>().moveSpeed - 0.5f);
            }
        }
    }
}




