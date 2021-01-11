using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Health health = null;

    public static event Action<Player> ServerOnPlayerSpawned;
    public static event Action<Player> ServerOnPlayerDespawned;
    private int shotsLeft = 15;
    private TMP_Text waterTankText;
    private int maxShots = 15;
    public override void OnStartServer()
    {
        health.ServerOnDie += ServerHandleDie;

        ServerOnPlayerSpawned?.Invoke(this);
      
    }
    private void Awake()
    {
        GameObject obj = GameObject.Find("WaterDrop");
        waterTankText = obj.GetComponentInChildren<TMP_Text>();
        waterTankText.text = maxShots.ToString();
    }

    public override void OnStopServer()
    {
        ServerOnPlayerDespawned?.Invoke(this);

        health.ServerOnDie -= ServerHandleDie;
    }

    public void HasShot()
    {
        shotsLeft--;
        waterTankText.text = shotsLeft.ToString();
    }

    public int GetShotsLeft()
    {
        return shotsLeft;
    }
    public void SetShotsLeft(int newTank)
    {
        shotsLeft = newTank;
        waterTankText.text = shotsLeft.ToString();
    }

    [Server]
    private void ServerHandleDie()
    {
       NetworkServer.Destroy(gameObject);
    }

   
}
