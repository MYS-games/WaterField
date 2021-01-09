using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private Health health = null;

    public override void OnStartServer()
    {
        health.ServerOnDie += ServerHandleDie;
    }

    public override void OnStopServer()
    {
        health.ServerOnDie -= ServerHandleDie;
    }

    [Server]
    private void ServerHandleDie()
    {
       // NetworkServer.Destroy(gameObject);
    }

}
