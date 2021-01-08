using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health = null;
    [SerializeField] private Image healthBar = null;

    private void Awake()
    {
        health.ClientOnHealthUpdated += ImageUpdateUI;
    }

    private void OnDestroy()
    {
        health.ClientOnHealthUpdated -= ImageUpdateUI;
    }

    private void ImageUpdateUI(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}
