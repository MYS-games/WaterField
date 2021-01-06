using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyMenu : MonoBehaviour
{
    [SerializeField] private GameObject lobbyUI = null;
    [SerializeField] private Button startGameButton = null; 

    private void Start()
    {
        WaterFieldNetworkManager.ClientOnConnected += HandleClientConnected;
        WaterFieldPlayer.AuthOnLobbyOwnerUpdated += AuthHandleOnLobbyOwnerUpdated;
    }

    private void OnDestroy()
    {
        WaterFieldNetworkManager.ClientOnConnected -= HandleClientConnected;
        WaterFieldPlayer.AuthOnLobbyOwnerUpdated -= AuthHandleOnLobbyOwnerUpdated;

    }

    private void HandleClientConnected()
    {
        lobbyUI.SetActive(true);
    }

    private void AuthHandleOnLobbyOwnerUpdated(bool state)
    {
        startGameButton.gameObject.SetActive(state);
    }

    public void StartGame()
    {
        NetworkClient.connection.identity.GetComponent<WaterFieldPlayer>().CmdStartGame();
    }

    public void LeaveLobby()
    {
        if(NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();

            SceneManager.LoadScene(0);
        }
    }
}
