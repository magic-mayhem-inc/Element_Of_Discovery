using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPlatform : MonoBehaviour
{
    float secsSinceCreation;

    private void Start()
    {
        Destroy(gameObject, 10);
        secsSinceCreation = 0;
    }

    private void Update()
    {
        secsSinceCreation = Time.deltaTime;
        if(secsSinceCreation >= 7)
        {
            PlatformDying();
        }
    }

    private void PlatformDying()
    {
        Quaternion shakyShake = Random.rotation;
        Quaternion currentRot = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(currentRot, shakyShake, Time.deltaTime);
    }
}
