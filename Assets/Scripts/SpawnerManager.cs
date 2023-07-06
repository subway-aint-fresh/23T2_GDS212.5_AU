using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SpawnerManager : MonoBehaviour
{
    //Written by ChatGPT
    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject oxygen;
    [SerializeField] private Transform target; // Target game object for viruses to move towards

    private Vector2 oxygenRange;
    private float elapsedTime = 0f;
    private int expansionCount = 0;
    private int maxExpansionCount = 3;
    private float oxygenSpawnRate = 1f;
    private int maxSpawnedOxygenCount = 750;
    private float virusSpeed = 1.5f;
    private float destroyOxygenPercentage = 1;
    private int virusSpawnAmount = 3;

    private List<GameObject> spawnedViruses = new List<GameObject>(); // List to keep track of spawned viruses

    private Coroutine oxygenSpawnCoroutine; // Coroutine reference for oxygen spawning

    private void Start()
    {
        oxygenRange = new Vector2(-6f, 6f);

        for (int i = 0; i < GameManager.spawnVirusStart; i++)
        {
            // Spawner Range
            SpawnRandomVirus(new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f)));
        }

        // Start spawning oxygen every second
        oxygenSpawnCoroutine = StartCoroutine(SpawnOxygenEverySecond());
    }

    private IEnumerator SpawnOxygenEverySecond()
    {
        while (GameManager.spawnedOxygenCount < maxSpawnedOxygenCount)
        {
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

            if (SwappingMechanic.isWhiteCellActive)
            {
                DestroyRandomOxygenClones(destroyOxygenPercentage); // Destroy oxygen clones based on the percentage
            }
            else
            {
                SpawnRandomOxygen(new Vector2(Random.Range(oxygenRange.x, oxygenRange.y), Random.Range(oxygenRange.x, oxygenRange.y)));

                GameManager.spawnedOxygenCount++;
                Debug.Log(GameManager.spawnedOxygenCount);
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
        GameObject spawnedVirus = Instantiate(prefab, position, Quaternion.identity, transform);
        spawnedViruses.Add(spawnedVirus); // Add the spawned virus to the list

        // Move the virus towards the target game object
        if (target != null)
        {
            StartCoroutine(MoveVirusTowardsTarget(spawnedVirus));
        }
    }

    private IEnumerator MoveVirusTowardsTarget(GameObject virusObject)
    {
        Rigidbody2D virusRigidbody = virusObject.GetComponent<Rigidbody2D>();

        while (target != null)
        {
            Vector2 direction = (target.position - virusObject.transform.position).normalized;
            virusRigidbody.velocity = direction * virusSpeed;

            yield return null;

            // Check if the virus object is destroyed
            if (virusObject == null || !spawnedViruses.Contains(virusObject))
            {
                break;
            }
        }
    }

    private void SpawnRandomOxygen(Vector2 position)
    {
        GameObject prefab = oxygen;
        Instantiate(prefab, position, Quaternion.identity, transform);
    }

    private void DestroyRandomOxygenClones(float percentage)
    {
        int oxygenCountToRemove = Mathf.CeilToInt(GameManager.spawnedOxygenCount * (percentage / 100f));

        for (int i = 0; i < oxygenCountToRemove; i++)
        {
            if (GameManager.spawnedOxygenCount > 0)
            {
                GameObject[] oxygenObjects = GameObject.FindGameObjectsWithTag("Oxygen");
                int randomIndex = Random.Range(0, oxygenObjects.Length);
                GameObject oxygenObject = oxygenObjects[randomIndex];

                Destroy(oxygenObject);
                GameManager.spawnedOxygenCount = GameManager.spawnedOxygenCount - oxygenCountToRemove;
            }
            else
            {
                break;
            }
        }
    }

    private void Update()
    {
        if (GameManager.virusMadeContactWithRBC == true)
        {
            GameManager.virusMadeContactWithRBC = false;
            GameManager.virusesCounter = GameManager.virusesCounter + virusSpawnAmount;
            for (int i = 0; i < virusSpawnAmount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f));
                SpawnRandomVirus(spawnPosition);
            }
        }
    }
}