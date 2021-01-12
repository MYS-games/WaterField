using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health health = null;
    [SerializeField] private Image healthBar = null;
   // private Image myHealthBar = null;
    private Image[] healthImages;

    private void Awake()
    {
        health.ClientOnHealthUpdated += ImageUpdateUI;
      /*  GameObject obj = GameObject.Find("MyHealthBar");
        healthImages = obj.GetComponentsInChildren<Image>();
        myHealthBar = healthImages[1];*/



    }

    private void OnDestroy()
    {
        health.ClientOnHealthUpdated -= ImageUpdateUI;
    }

    private void ImageUpdateUI(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
      //  myHealthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}
