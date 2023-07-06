using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.oxygenCollected=0;
        //Increase oxygen bar
    }
}
