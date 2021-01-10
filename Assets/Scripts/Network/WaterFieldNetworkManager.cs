﻿using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterFieldNetworkManager : NetworkManager
{
    [SerializeField] private GameObject theActualPlayer = null;
    [SerializeField] private GameOverHandler gameOverPrefab = null;

    public static event Action ClientOnConnected;
    public static event Action ClientOnDisconnected;

    private bool isGameInProgress = false;

    public List<WaterFieldPlayer> Players { get; } = new List<WaterFieldPlayer>();

    #region Server

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (!isGameInProgress) { return; }

        conn.Disconnect();
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
      
        WaterFieldPlayer player = conn.identity.GetComponent<WaterFieldPlayer>();

        Players.Add(player);

        player.SetPartyOwner(Players.Count == 1);
    }

    public override void OnServerDisconnect(NetworkConnection conn)
    {
        WaterFieldPlayer player = conn.identity.GetComponent<WaterFieldPlayer>();
        Players.Remove(player);

        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer()
    {
        Players.Clear();
        isGameInProgress = false;
    }

    public void StartGame()
    {
        if(Players.Count < 1) { return; }

        isGameInProgress = true;

        ServerChangeScene("NewWorldScene");
    }


    public override void OnServerSceneChanged(string newSceneName)
    {
        base.OnServerChangeScene(newSceneName);

        if (SceneManager.GetActiveScene().name.StartsWith("NewWorldScene"))
        {
            GameOverHandler gameOverInstance = Instantiate(gameOverPrefab);
            NetworkServer.Spawn(gameOverInstance.gameObject);

            foreach (WaterFieldPlayer player in Players)
            {
                GameObject playerInstance = Instantiate(
                    theActualPlayer,
                    GetStartPosition().position,
                    Quaternion.identity);

                NetworkServer.Spawn(playerInstance, player.connectionToClient);
            }
        }
    }

    #endregion

    #region Client

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        ClientOnConnected?.Invoke();
    }
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        ClientOnDisconnected?.Invoke();
    }

    public override void OnStopClient()
    {
        Players.Clear();
    }

    #endregion



}
