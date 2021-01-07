using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFieldPlayer : NetworkBehaviour
{

   /* [SyncVar(hook = nameof(HandleIndexSelction))] 
    private int selectedPlayerIndex = -1;*/

    [SyncVar(hook = nameof(AuthHandleLobbyOwnerUpdated))]
    private bool isLobbyOwner = false;

    public static event Action<bool> AuthOnLobbyOwnerUpdated;

    public bool GetIsLobbyOwner()
    {
        return isLobbyOwner;
    }

   /* public int GetSelectedPlayerIndex()
    {
        return selectedPlayerIndex;
    }*/

  /*  [Server]
    public void SetSelectedPlayerIndex(int selectedIndex)
    {
        selectedPlayerIndex = selectedIndex;
    }*/

    [Server]
    public void SetPartyOwner(bool state)
    {
        isLobbyOwner = state;
    }

   /* [Command]
    public void CmdSelectNewIndex(int newIndex)
    {
        SetSelectedPlayerIndex(newIndex);
    }*/

    [Command]
    public void CmdStartGame()
    {
        if (!isLobbyOwner) { return; }

       ((WaterFieldNetworkManager)NetworkManager.singleton).StartGame();
    }

    public override void OnStartClient()
    {
        if (NetworkServer.active) { return; }

        ((WaterFieldNetworkManager)NetworkManager.singleton).Players.Add(this);
    }
    public override void OnStopClient()
    {
        if (!isClientOnly) { return; }

        ((WaterFieldNetworkManager)NetworkManager.singleton).Players.Remove(this);
    }

    /*private void HandleIndexSelction(int _, int newSelectedIndex)
    {
        if (!hasAuthority) { return; }

        SetSelectedPlayerIndex(newSelectedIndex);
    }

    public void TrySelectIndex(int selectedIndex)
    {
        CmdSelectNewIndex(selectedIndex);
    }*/

    private void AuthHandleLobbyOwnerUpdated(bool _, bool newState)
    {
        if (!hasAuthority) { return; }

        AuthOnLobbyOwnerUpdated?.Invoke(newState);
    }

}
