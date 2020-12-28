using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstPage = null;

    public void HostLobby()
    {
        firstPage.SetActive(false);

        NetworkManager.singleton.StartHost();
    }
}
