using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using System;

public class Shoot : NetworkBehaviour
{
    [SerializeField] private float range = 10f;
    [SerializeField] private int damage = 20;

    public Camera cam;
    public GameObject waterPrefab;
    public Transform waterSpawn;


    void Update()
    {
        /* if (!isLocalPlayer)
         {
             Debug.Log("in return"); return;
         }*/

        if (Input.GetKey(KeyCode.Space))
        {
            CmdFire();

            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range)) { return;}
            
            if (hit.collider.TryGetComponent<Health>(out Health targetHealth))
            {
                targetHealth.DealDamage(damage);
            }
        }

    }
    [Command]
    private void CmdFire()
    {
        ServerShoot();
    }

    [Server]
    public void ServerShoot()
    {
        GameObject water = (GameObject)Instantiate(
            waterPrefab,
            waterSpawn.position,
            waterSpawn.rotation);

        NetworkServer.Spawn(water);

        Destroy(water, 2);
    }


}