using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTap : MonoBehaviour
{

    public ParticleSystem waterLeak;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            openTap();
        }
    }

    void openTap()
    {
        Instantiate(waterLeak);
        waterLeak.Play();
    }
}
