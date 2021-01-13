using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : NetworkBehaviour
{
    [SerializeField] private GameObject cameraPlace = null;
    //public GameObject CameraMountPoint;
    private Camera myCamera;


    public override void OnStartAuthority()
    {
        myCamera = Camera.main;
        if (isLocalPlayer)
        {
            GetComponent<Canvas>().enabled = true;
        }
    }
    void Update()
    {
        if (!hasAuthority) { return; }

       
        Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
        cameraTransform.parent = cameraPlace.transform;  //Make the camera a child of the mount point
        cameraTransform.position = new Vector3(cameraPlace.transform.position.x, cameraPlace.transform.position.y, cameraPlace.transform.position.z);  //Set position/rotation same as the mount point
        cameraTransform.rotation = cameraPlace.transform.rotation;
        
    }
}
