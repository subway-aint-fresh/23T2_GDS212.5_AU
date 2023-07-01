using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject virus;

    private void Start()
    {

        for(int i=0; i< GameManager.spawnVirusStart; i++)
        {
            //Spawner Range
            SpawnRandomVirus(new Vector2(Random.Range(-60f, 60f), Random.Range(-50f, 50f)));
        }
    }
    private void SpawnRandomVirus(Vector2 position)
    {
        GameObject prefab = virus;

        Instantiate(prefab, position, Quaternion.identity, transform);
    }
}
