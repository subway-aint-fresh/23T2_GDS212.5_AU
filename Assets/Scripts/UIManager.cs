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

    private float damageInterval = 4f;
    private float damageTimer = 0f;

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
    }

    void TakeDamage()
    {
        if (healthAmount > 0)
        {
            healthAmount -= 10;
            healthBar.fillAmount = healthAmount / 100f;
            Debug.Log(healthAmount);
        }
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);

        healthBar.fillAmount = healthAmount / 100f;
    }
}
