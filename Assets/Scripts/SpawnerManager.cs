using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject virus;
    [SerializeField] private GameObject oxygen;

    private void Start()
    {

        for(int i=0; i< GameManager.spawnVirusStart; i++)
        {
            //Spawner Range
            SpawnRandomVirus(new Vector2(Random.Range(-12f, 12f), Random.Range(-10f, 10f)));
        }

        for(int i=0; i<GameManager.spawnOxygenStart; i++)
        {
            SpawnRandomOxygen(new Vector2(Random.Range(-6f, 6f), Random.Range(-5f, 5f)));
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
