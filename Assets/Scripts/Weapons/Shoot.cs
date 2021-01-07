using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;
using System;

public class Shoot : NetworkBehaviour
{
    [SerializeField] private float range = 50f;
    [SerializeField] private int damage = 20;
    [SerializeField] private Camera cam = null;
    //[SerializeField] private ParticleSystem waterEffect = null;

    private void Start()
    {
        cam = Camera.main;
    }

    [Server]
    private void DealDamage(WaterFieldPlayer hitPlayer, int damage)
    {
        hitPlayer.GetComponent<Health>().ServerDealDamage(damage);
    }

    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z was pressed");
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range)) { return; }
            Debug.Log("raycast was found");
            if (hit.collider.TryGetComponent<WaterFieldPlayer>(out WaterFieldPlayer targetPlayer))
            {
                DealDamage(targetPlayer, damage);

                //targetPlayer.GetComponent<Health>().ServerDealDamage(damage);
                int temp = targetPlayer.GetComponent<Health>().GetHealth();
                Debug.Log(temp);
            }
        }

    }
}