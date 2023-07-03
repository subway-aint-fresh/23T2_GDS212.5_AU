using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject oxygen;

    private Vector2 oxygenRange;
    private float elapsedTime = 0f;
    private int expansionCount = 0;
    private int maxExpansionCount = 3;
    private float oxygenSpawnRate = 1f;
    private int spawnedOxygenCount = GameManager.spawnedOxygenCount;
    private int maxSpawnedOxygenCount = 750;

    private void Start()
    {
        oxygenRange = new Vector2(-6f, 6f);

        for (int i = 0; i < 1000; i++)
        {
            // Spawner Range
            SpawnRandomVirus(new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f)));
        }

        for (int i = 0; i < GameManager.spawnOxygenStart; i++)
        {
            SpawnRandomOxygen(new Vector2(Random.Range(oxygenRange.x, oxygenRange.y), Random.Range(oxygenRange.x, oxygenRange.y)));
        }

        // Start spawning oxygen every second
        StartCoroutine(SpawnOxygenEverySecond());
    }

    private IEnumerator SpawnOxygenEverySecond()
    {
        while (spawnedOxygenCount < maxSpawnedOxygenCount)
        {
            SpawnRandomOxygen(new Vector2(Random.Range(oxygenRange.x, oxygenRange.y), Random.Range(oxygenRange.x, oxygenRange.y)));

            spawnedOxygenCount++;
            Debug.Log(spawnedOxygenCount);

            yield return new WaitForSeconds(oxygenSpawnRate); // Wait for the specified spawn rate

            elapsedTime += oxygenSpawnRate;

            // Every 10 seconds, expand the oxygen range by 10 and double the spawn rate
            if (elapsedTime >= 10f)
            {
                if (expansionCount < maxExpansionCount)
                {
                    ExpandOxygenRange();
                    oxygenSpawnRate *= 0.5f; // Double the spawn rate
                    expansionCount++;
                }
                elapsedTime = 0f;
            }
        }
    }

    private void ExpandOxygenRange()
    {
        oxygenRange.x -= 10f;
        oxygenRange.y += 10f;

        Debug.Log("Expanded oxygen range: " + oxygenRange);
        Debug.Log("New oxygen spawn rate: " + oxygenSpawnRate);

        // After expanding the range, check if it has reached the maximum expansion count
        if (expansionCount >= maxExpansionCount)
        {
            Debug.Log("Reached maximum expansion count: " + expansionCount);
        }
    }

    private void SpawnRandomVirus(Vector2 position)
    {
        GameObject prefab = virus;
        Instantiate(prefab, position, Quaternion.identity, transform);
    }

    private void SpawnRandomOxygen(Vector2 position)
    {
        GameObject prefab = oxygen;
        Instantiate(prefab, position, Quaternion.identity, transform);
    }
}