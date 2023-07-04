using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int virusSpeed = 2;

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
            if (!SwappingMechanic.isWhiteCellActive)
            {
                SpawnRandomOxygen(new Vector2(Random.Range(oxygenRange.x, oxygenRange.y), Random.Range(oxygenRange.x, oxygenRange.y)));

                GameManager.spawnedOxygenCount = GameManager.spawnedOxygenCount + 1;
                Debug.Log(GameManager.spawnedOxygenCount);
            }

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
                DestroyRandomOxygenClones(0.5f); // Destroy 0.5% of oxygen clones
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
                GameManager.spawnedOxygenCount--;
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
            int spawnAmount = 2; // Randomly determine the number of viruses to spawn (between 1 and 3)
            GameManager.virusesCounter = GameManager.virusesCounter + 2;
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector2 spawnPosition = new Vector2(Random.Range(-30f, 30f), Random.Range(-30f, 30f));
                SpawnRandomVirus(spawnPosition);
            }
        }
    }
}
