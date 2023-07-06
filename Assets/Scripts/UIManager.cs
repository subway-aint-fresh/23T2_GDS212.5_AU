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
    [SerializeField] private float healthAmount = 100f;

    [SerializeField] private float damageInterval = 4f;
    [SerializeField] private float damageAmount = 10f;

    private float damageTimer = 0f;

    [SerializeField] private int oxygenCollected;

    void Update()
    {
        textOxygen.text = "Oxygen: " + GameManager.spawnedOxygenCount;
        textVirus.text = "Virus: " + GameManager.virusesCounter;
        textOxygenCollected.text = "Oxygen Collected: " + GameManager.oxygenCollected;

        if (GameManager.virusesCounter > 0)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                TakeDamage();
                damageTimer = 0f;
            }
        }

        Heal(oxygenCollected);
    }
    
    //Called if there are virus in the scene 
    void TakeDamage()
    {
        if (healthAmount > 0)
        {
            healthAmount -= damageAmount;
            healthBar.fillAmount = healthAmount / 100f;
            Debug.Log(healthAmount);
        }
    }

    //Called if oxygen has been collected and in trigger of heart
    //Healed by number of oxygen collected
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
