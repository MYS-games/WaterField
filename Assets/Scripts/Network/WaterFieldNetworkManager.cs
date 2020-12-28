using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFieldNetworkManager : NetworkManager
{
    public static event Action ClientOnConnected;
    public static event Action ClientOnDisconnected;

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

}
