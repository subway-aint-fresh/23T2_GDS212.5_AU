using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.virusesDefeatedCounter++;
        Debug.Log("Destroyed");
        Destroy(gameObject);
    }
}
