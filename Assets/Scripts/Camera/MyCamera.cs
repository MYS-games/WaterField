using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : NetworkBehaviour
{
    //public GameObject CameraMountPoint;
    private Camera myCamera;


    public override void OnStartAuthority()
    {
        myCamera = Camera.main;
    }
    void Update()
    {
        if (!hasAuthority) { return; }

       
        Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
        cameraTransform.parent = transform;  //Make the camera a child of the mount point
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);  //Set position/rotation same as the mount point
        cameraTransform.rotation = transform.rotation;
        
    }
}
