﻿using System.Collections;
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
    [SerializeField] private Player myWaterTank = null;
    private ParticleSystem waterEffect;


    public override void OnStartServer()
    {
        waterEffect = this.GetComponentInChildren<ParticleSystem>();
        cam = Camera.main;
    }

    [Command]
    private void CmdDealDamage(Player hitPlayer, int damage)
    {
        hitPlayer.GetComponent<Health>().ServerDealDamage(damage);

    }

    [ClientCallback]
    void Update()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        if (waterEffect == null)
        {
            waterEffect = this.GetComponentInChildren<ParticleSystem>();
        }

        if (!hasAuthority) { return; }

        if (myWaterTank.GetShotsLeft() == 0) { return; }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            waterEffect.Play();
            myWaterTank.HasShot();
            if (!Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range)) { return; }
            if (hit.collider.TryGetComponent<Player>(out Player targetPlayer))
            {
                CmdDealDamage(targetPlayer, damage);
            }
        }

    }
}