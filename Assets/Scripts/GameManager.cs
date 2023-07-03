using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Virus
    public static int spawnVirusStart = 2;
    public static int virusesSpawned = spawnVirusStart;
    public static int virusesDefeatedCounter = 0;
    public static int maxVirusSpread = 21;

    //Oxygen
    public static int spawnOxygenStart = 3;
    public static int OxygenSpawned = spawnVirusStart;
    public static int spawnedOxygenCount = 0;

    //Max Area = Vector2(Random.Range(-60f, 60f), Random.Range(-50f, 50f))
}
