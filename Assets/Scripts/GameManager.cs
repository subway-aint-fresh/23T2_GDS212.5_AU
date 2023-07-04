using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Virus
    public static int spawnVirusStart = 6;
    public static int virusesCounter = spawnVirusStart;
    public static int virusesDefeatedCounter = 0;
    public static bool virusMadeContactWithRBC = false;

    //Oxygen
    public static int spawnOxygenStart = 3;
    public static int OxygenSpawned = spawnVirusStart;
    public static int spawnedOxygenCount = 0;

    //Max Area = Vector2(Random.Range(-30f, 30f, Random.Range(-30f, 30f))
}
