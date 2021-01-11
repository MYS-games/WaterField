using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : NetworkBehaviour
{
    public GameObject explosionEffect;
    public int explosionForce = 10;
    public float radius = 0f;

    // Start is called before the first frame update
    void Update()
    {

    }

   /* private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        //applying them a force
        foreach (Collider nearCollider in colliders)
        {
            Rigidbody rig = nearCollider.GetComponent<Rigidbody>();
            Debug.Log(nearCollider + " NEAR NAME");
            if (nearCollider.TryGetComponent<Player>(out Player targetPlayer))
            {
                // Debug.Log(rig.gameObject.name + "  NAME");
              //  Instantiate(explosionEffect, transform.position, transform.rotation);
                CmdDealDamage(targetPlayer, explosionForce);
            }
        }

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 1f);
    }*/

    [Client]
    private void OnCollisionEnter(Collision target)
    {
        if (!hasAuthority) { return; }
        // after we touched an enemy, deactivate gameObject
        //Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        // Debug.Log(colliders.Length + " ArrayLEngth");

        GameObject splash =  Instantiate(explosionEffect, transform.position, transform.rotation);
        NetworkServer.Spawn(splash, connectionToClient);
        // Explode();

        if (target.collider.TryGetComponent<Player>(out Player targetPlayer))
        {
            // Debug.Log(rig.gameObject.name + "  NAME");
            //  Instantiate(explosionEffect, transform.position, transform.rotation);
            CmdDealDamage(targetPlayer, explosionForce);
            Debug.Log("after cmdDEAL");
        }
        NetworkManager.Destroy(splash, 2f);
        

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        NetworkManager.Destroy(gameObject, 2f);
    }

    [Command]
    private void CmdDealDamage(Player hitPlayer, int damage)
    {
        Debug.Log("on cmdDEAL");
        hitPlayer.GetComponent<Health>().ServerDealDamage(damage);
    }
}