using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    // Public Variables
    public float speed;
    public float jumpForce;
    public static bool isDead;

    // Booleans
    bool isGrounded;
    bool canControl;

    Vector3 jump;

    enum Magic {None, Water, Fire, Earth, Air, Steam, Mud, Rain, Metal, Lightning, Sand, Life};

    Magic currentMagic;

    void Awake()
    {
        currentMagic = Magic.None;
        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Jump Vectors
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        canControl = true;
        isDead = false;
    }

    void Update()
    {
        // Jump Code
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    void FixedUpdate()
    {
        // Player Movement- Forwards and Sideways
        if (canControl == true)
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float strafe = Input.GetAxis("Horizontal") * speed;
            translation *= Time.deltaTime;
            strafe *= Time.deltaTime;

            transform.Translate(strafe, 0, translation);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        // Interact Code
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Item"))
            {
                InventoryManager.instance.AddToInventory(other.name, other.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        MagicCast(currentMagic);
    }

    // Character resets back to the ground and can jump again
    void OnCollisionEnter()
    {
        isGrounded = true;
    }


    void MagicCast(Magic current)
    {
        switch(current)
        {
            case Magic.Water:
                CastWater();
                break;

            case Magic.Fire:

                break;

            case Magic.Earth:

                break;

            case Magic.Air:

                break;
            default:

                break;
        }
    }

    void CastWater ()
    {

    }

}
