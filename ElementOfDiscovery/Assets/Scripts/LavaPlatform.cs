using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlatform : MonoBehaviour
{
    float secsSinceCreation;
    bool numPlatsManaged;

    private void Start()
    {
        Destroy(gameObject, 10);
        secsSinceCreation = 0;
        numPlatsManaged = false;
    }

    private void Update()
    {
        secsSinceCreation += Time.deltaTime;
        if(secsSinceCreation >= 7 && secsSinceCreation < 9.8)
        {
            PlatformDying();
        }
        else if (secsSinceCreation >= 9.8 && !numPlatsManaged)
        {
            LavaPlatformManager.numOfPlatforms--;
            numPlatsManaged = true;
        }
    }

    private void PlatformDying()
    {
        Quaternion shakyShake = Random.rotation;
        Quaternion currentRot = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(currentRot, shakyShake, Time.deltaTime);
    }
}
