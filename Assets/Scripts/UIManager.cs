using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOxygen;
    [SerializeField] private TextMeshProUGUI textVirus;
    [SerializeField] private TextMeshProUGUI textOxygenCollected;

    [SerializeField] private Image healthBar;
    public static float healthAmount = 100f;

    [SerializeField] private float damageInterval = 4f;
    [SerializeField] private float damageAmount = 10f;

    private float _damageTimer = 0f;
    void Update()
    {
        textOxygen.text = "Oxygen: " + GameManager.spawnedOxygenCount;
        textVirus.text = "Virus: " + GameManager.virusesCounter;
        textOxygenCollected.text = "Oxygen Collected: " + GameManager.oxygenCollected;

        if (GameManager.virusesCounter > 0)
        {
            _damageTimer += Time.deltaTime;
            if (_damageTimer >= damageInterval)
            {
                TakeDamage();
                _damageTimer = 0f;
                if (GameManager.spawnedOxygenCount <= 0)
                {
                    healthAmount = healthAmount - 10;
                }
            }
        }
        if (healthBar != null)
        {
            healthBar.fillAmount = healthAmount / 100f;
        }
    }
    
    //Called if there are virus in the scene 
    public void TakeDamage()
    {
        if (healthBar != null)
        {
            if (healthAmount > 0)
            {
                healthAmount -= damageAmount;
                healthBar.fillAmount = healthAmount / 100f;
                Debug.Log(healthAmount);
            }
        }

    }

    //Called if oxygen has been collected and in trigger of heart
    //Healed by number of oxygen collected
    public static void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
    }
}
