using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOxygen;
    [SerializeField] private TextMeshProUGUI textVirus;
    [SerializeField] private TextMeshProUGUI textOxygenCollected;
    void Update()
    {
        textOxygen.text = "Oxygen: " + GameManager.spawnedOxygenCount;
        textVirus.text = "Virus: " + GameManager.virusesCounter;
        textOxygenCollected.text = "Oxygen Collected: " + GameManager.oxygenCollected;
    }
}
