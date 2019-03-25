using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    public GameObject platform;
    public Transform platformParent;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Water") && LavaPlatformManager.numOfPlatforms < 3)
        {
            Vector3 originPoint = collision.contacts[0].point;
            Quaternion rotation = new Quaternion();
            Instantiate(platform, originPoint, rotation, platformParent);
            LavaPlatformManager.numOfPlatforms++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Player"))
        {
            PlayerController.isDead = true;
            
        }
    }
}
