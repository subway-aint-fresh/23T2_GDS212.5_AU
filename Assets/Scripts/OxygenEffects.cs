using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!SwappingMechanic.isWhiteCellActive)
        {
            GameManager.spawnedOxygenCount = GameManager.spawnedOxygenCount - 1;
            
            Destroy(gameObject);
        }
    }
}
