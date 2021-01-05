using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : NetworkBehaviour
{
    [SerializeField] private int maxHealth = 100;
    
    private GameObject healthBar = null;

    [SyncVar(hook = nameof(HandleHealthUpdated))]
    private int currentHealth;

    public event Action ServerOnDie;
    public event Action<int, int> ClientOnHealthUpdated;

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("WetBar");
    }

    #region Server

    public override void OnStartServer()
    {
        currentHealth = maxHealth;

        //TODO: handle game over

        //UnitBase.ServerOnPlayerDie += ServerHandlePlayerDie;
    }

    [Server]
    public void DealDamage(int damageAmount)
    {
        if (currentHealth == 0) { return; }

        currentHealth = Mathf.Max(currentHealth - damageAmount, 0);

        if(healthBar != null)
        {
            HealthBar updatedBar = healthBar.GetComponent<HealthBar>();
            updatedBar.SetHealth(currentHealth);
        }
        else
        {
            Debug.Log("healthBar is null");
        }
        
        if (currentHealth != 0) { return; }

        ServerOnDie?.Invoke();
    }


    #endregion

    #region Client

    private void HandleHealthUpdated(int _, int newHealth)
    {
        ClientOnHealthUpdated?.Invoke(newHealth, maxHealth);
    }

    #endregion

}
