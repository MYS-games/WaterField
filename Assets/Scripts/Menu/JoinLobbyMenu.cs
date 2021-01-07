using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Mirror;

public class JoinLobbyMenu : MonoBehaviour
{
    [SerializeField] private GameObject enterPage = null;
    [SerializeField] private TMP_InputField addressInput = null;
    [SerializeField] private Button joinButton = null;

    private void OnEnable()
    {
        WaterFieldNetworkManager.ClientOnConnected += HandleClientConnected;
        WaterFieldNetworkManager.ClientOnDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        WaterFieldNetworkManager.ClientOnConnected -= HandleClientConnected;
        WaterFieldNetworkManager.ClientOnDisconnected -= HandleClientDisconnected;
    }

    public void Join()
    {
        string address = addressInput.text;
        NetworkManager.singleton.networkAddress = address;
        NetworkManager.singleton.StartClient();

       // joinButton.interactable = false;
    }

    private void HandleClientConnected() 
    {
        joinButton.interactable = true;

        gameObject.SetActive(false);
        enterPage.SetActive(false);
    }
    private void HandleClientDisconnected() 
    {
        joinButton.interactable = true;
    }

}
