using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public GameObject explosionEffect;
    public float explosionForce = 10f;
    public float radius = 0f;

    // Start is called before the first frame update
    void Update()
    {
        
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        //applying them a force
        foreach(Collider nearCollider in colliders)
        {
            Rigidbody rig = nearCollider.GetComponent<Rigidbody>();
            Debug.Log(nearCollider + " NEAR NAME" );
            if(rig != null && rig.gameObject != transform.gameObject)
            {
                Debug.Log(rig.gameObject.name + "  NAME");
                //rig.AddExplosionForce(explosionForce, transform.position, radius, 0f, ForceMode.Impulse);
               // rig.AddForce(Vector3.back * 500);
                Instantiate(explosionEffect, transform.position, transform.rotation);

                gameObject.GetComponent<MeshRenderer>().enabled = false;
                Destroy(gameObject, 1f);
              //  Destroy(explosionEffect, 1f);
            }
        }     
    }
    private void OnCollisionEnter(Collision target)
    { // after we touched an enemy, deactivate gameObject
        if (target.gameObject.tag != "Player")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Debug.Log(colliders.Length + " ArrayLEngth");
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Explode();
        }

        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, 2f);
    }

   /* private void OnCollisionStay(Collision target)
    { // after we touched an enemy, deactivate gameObject
        if (target.gameObject.tag != "Player")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Debug.Log(colliders.Length + " ArrayLEngth");
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Explode();
        }

    }*/


}
