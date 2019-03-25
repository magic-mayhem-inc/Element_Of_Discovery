using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothVector;
    public float sensitivity;
    public float smoothing;

    // Constraint of camera's vertical movement
    public float minY;
    public float maxY;

    GameObject player;

    void Start()
    {
        player = this.transform.parent.gameObject;
    }

    void Update()
    {
        // Maths the camera's movement as well as smoothing it out and adjusting the reactivity to input
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
        smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
        mouseLook += smoothVector;
        mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);

        // Rotates the player with the camera's rotation
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}

