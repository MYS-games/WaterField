using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Health health = null;

    public static event Action<Player> ServerOnPlayerSpawned;
    public static event Action<Player> ServerOnPlayerDespawned;

    public override void OnStartServer()
    {
        health.ServerOnDie += ServerHandleDie;

        ServerOnPlayerSpawned?.Invoke(this);
    }

    public override void OnStopServer()
    {
        ServerOnPlayerDespawned?.Invoke(this);

        health.ServerOnDie -= ServerHandleDie;
    }

    [Server]
    private void ServerHandleDie()
    {
       NetworkServer.Destroy(gameObject);
    }

}
