using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!SwappingMechanic.isWhiteCellActive && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            UIManager.Heal(GameManager.oxygenCollected * 10);
            Debug.Log("healed:" + GameManager.oxygenCollected);

            GameManager.oxygenCollected = 0;
        }
    }
}
