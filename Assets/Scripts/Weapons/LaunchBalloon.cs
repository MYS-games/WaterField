using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LaunchBalloon : NetworkBehaviour
{
    public float throwForce = 40f;
    public GameObject ballonPrefab;
    float range = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CmdLaunch();

        }
    }

    [Command]
    public void CmdLaunch()
    {
        GameObject balloon = Instantiate(ballonPrefab, transform.position, transform.rotation);
        NetworkServer.Spawn(balloon);
        // balloon.GetComponent<Rigidbody>().velocity = balloon.transform.forward * 6.0f;
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        rb.AddForce(balloon.transform.forward * throwForce, ForceMode.Impulse);

        NetworkServer.Spawn(balloon);

    }


}