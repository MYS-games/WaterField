using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : NetworkBehaviour
{
    public static event Action<string> ClientOnGameOver;

    private List<Player> players = new List<Player>();

    #region Server

    public override void OnStartServer()
    {
        Player.ServerOnPlayerSpawned += ServerOnPlayerSpawn;
        Player.ServerOnPlayerDespawned += ServerOnPlayerDespawn;
    }

    public override void OnStopServer()
    {
        Player.ServerOnPlayerSpawned -= ServerOnPlayerSpawn;
        Player.ServerOnPlayerDespawned -= ServerOnPlayerDespawn;
    }

    [Server]
    private void ServerOnPlayerSpawn(Player player)
    {
        players.Add(player);
    }

    [Server]
    private void ServerOnPlayerDespawn(Player player)
    {
        players.Remove(player);

        if(players.Count != 1) { return; }

        Debug.Log("Game Over");

        int winnerId = players[0].connectionToClient.connectionId;
        RpcGameOver($"player {winnerId}");
    }

    #endregion

    #region Client

    [ClientRpc]
    private void RpcGameOver(string winner)
    {
        ClientOnGameOver?.Invoke(winner);
    }

    #endregion
}
