using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LaunchBalloon : NetworkBehaviour
{
    public float throwForce = 40f;
    public GameObject balloonPrefab;
    public GameObject balloonSpawner;
    
    //float range = 10f;
    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }
        if (Input.GetKeyDown(KeyCode.X))
        {
            CmdLaunch();

        }
    }

    [Command]
    public void CmdLaunch()
    {
        GameObject balloon = Instantiate(balloonPrefab, balloonSpawner.transform.position, balloonSpawner.transform.rotation);
        NetworkServer.Spawn(balloon,connectionToClient);
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        rb.AddForce(balloon.transform.forward * throwForce, ForceMode.Impulse);
        NetworkManager.Destroy(balloon, 5f);
    }

   /* private Vector3 SetBallisticTrajectory(Vector3 startPosition, Vector3 targetPosition, float velocity, float angle, float time)
    {
        // This function take in a angle into account when calculating the ballistic trajectory. The velocity is also a float, instead of a vector.
        // This function doesn't require the velocity to be pre-calculated for a proper ballistic trajectory.
        Vector3 direction = (targetPosition - startPosition);
        Vector3 directionVelocity = (velocity * (direction.normalized));
        Vector3 currentVectorPosition = startPosition;

        currentVectorPosition.x += ((directionVelocity.x * Mathf.Cos(angle)) * time);
        currentVectorPosition.y += ((directionVelocity.y * Mathf.Sin(angle)) * time) - (1.0f / 2.0f * Physics.gravity.magnitude * (time * time));
        currentVectorPosition.z += ((directionVelocity.z * Mathf.Cos(angle)) * time);

        return currentVectorPosition;
    }*/

}