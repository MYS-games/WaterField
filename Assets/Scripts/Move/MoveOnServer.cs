using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveOnServer : NetworkBehaviour
{
    [SerializeField] public float speed = 15.0f;
    [SerializeField] public float rotationSpeed = 100.0f;


    [ClientCallback]
    private void Update()
    {
        if (!hasAuthority) { return; }

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
        RpcMovue();
    }

    [ClientRpc]
    public void RpcMovue()
    {
       // Debug.Log("someone moved");
    }
}
