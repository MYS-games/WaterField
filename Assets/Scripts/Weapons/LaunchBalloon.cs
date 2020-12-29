using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBalloon : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject ballonPrefab;
    float range = 10f;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
             Launch();
            //Shoot();
        }
    }
    private void Launch()
    {
        GameObject balloon = Instantiate(ballonPrefab, transform.position, transform.rotation);
        /* Rigidbody rb = ballon.GetComponent<Rigidbody>();
        rb.AddForce(spawnpoint.forward * throwForce, ForceMode.Impulse);*/
        Transform v = transform;
        v.position = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        balloon.GetComponent<Rigidbody>().AddForce(v.forward * throwForce, ForceMode.VelocityChange);
        //balloon.GetComponent<Rigidbody>().isKinematic = true;
    }

    /* void Shoot()
     {
         RaycastHit hit;
         if (Physics.Raycast(spawnpoint.transform.position, spawnpoint.transform.forward, out hit, range))
         {
             GameObject g = Instantiate(ballonPrefab, hit.point, Quaternion.LookRotation(hit.normal));
             //Destroy(g, 2f);
             g.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * throwForce, ForceMode.VelocityChange);
         }
     }*/

   /* public class SpearAndArrow : MonoBehaviour
    {
        private Rigidbody myBody;

        public float speed = 30f;

        public float deactivateTimer = 3f;

        public float damage = 15f;

        private void Awake()
        {
            myBody = GetComponent<Rigidbody>();
        }

        void Start()
        {
            Invoke("DeactivateGameObject", deactivateTimer);
        }

        public void Launch(Camera mainCamera)
        {
            myBody.velocity = mainCamera.transform.forward * speed;

            transform.LookAt(transform.position + myBody.velocity);
        }

        void DeactivateGameObject()
        {
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider target)
        { // after we touched an enemy, deactivate gameObject
            if (target.tag == Tags.ENEMY_TAG)
            {
                target.GetComponent<HealthScript>().ApplyDamage(damage);

                gameObject.SetActive(false);
            }
        }
    }

    void ThrowArrowOrSpear(bool throwArrow)
    {
        if (throwArrow)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = ArrowBowStartPosition.position;

            arrow.GetComponent<SpearAndArrow>().Launch(mainCam);
        }
  
    }
*/

}
