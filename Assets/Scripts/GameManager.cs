using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Virus
    public static int spawnVirusStart = 15;
    public static int virusesCounter = spawnVirusStart;
    public static int virusesDefeatedCounter = 0;
    public static bool virusMadeContactWithRBC = false;

    //Oxygen
    public static int spawnedOxygenCount = 0;
    public static float oxygenCollected = 0f;

    //Max Area = Vector2(Random.Range(-36f, 36f, Random.Range(-36f, 36f))
}
