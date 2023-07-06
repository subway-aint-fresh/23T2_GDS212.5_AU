using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VirusEffects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SwappingMechanic.isWhiteCellActive && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.virusesCounter = GameManager.virusesCounter - 1;
            GameManager.virusesDefeatedCounter++;
            Debug.Log("Destroyed");
            Destroy(gameObject);
            // There is a bug with the cell being white and when the virus touches the red blood cell the vir
        }

        if (!SwappingMechanic.isWhiteCellActive && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameManager.virusesCounter = GameManager.virusesCounter - 1;
            UIManager.healthAmount = UIManager.healthAmount - 1;
            GameManager.virusMadeContactWithRBC = true;
            Destroy(gameObject);
        }
    }
}
