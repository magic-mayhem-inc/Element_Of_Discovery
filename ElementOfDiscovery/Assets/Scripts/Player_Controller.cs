using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody rb;

    public Image img;

    // Public Variables
    public float speed;
    public float jumpForce;
    public Vector3 jump;

    public Text speechText;
    public Text interactText;

    // Booleans
    public bool isImgOn;
    public bool isGrounded;
    public bool interactiveObj;
    public bool canControl;

    // Locked/Unlocked Elements - Boolean
    public bool fireStone;
    public bool waterStone;
    public bool earthStone;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Jump Vectors
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        // Text
        speechText.text = "";

        // Speech Box Background
        img.enabled = true;
        isImgOn = true;

        // Water Element Unlocked at Start
        waterStone = true;
    }

    void Update()
    {
        // Jump Code
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Set Speech Box Inactive
        interactiveObj = false;

    }

    void FixedUpdate()
    {
        // Player Movement- Forwards and Sideways
        if (canControl == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rb.AddForce(movement * speed);
        }
        
        // Determines if speech box will appear if character initiates interaction
        if (interactiveObj == true)
        {
            if (isImgOn == true)
            {

                img.enabled = false;
                isImgOn = false;
            }

            else
            {

                img.enabled = true;
                isImgOn = true;
            }
        }

    }

    // Character resets back to the ground and can jump again
    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Empty Object with "Fire Elemental" Tag is interacting with player
        if (other.gameObject.CompareTag("Fire Elemental"))
        {
            interactiveObj = true;
            setInteractive();
            if (Input.GetKeyDown(KeyCode.X))
            {
                canControl = false;
                speechText.text = "Congratulations, traveler. You've passed the Trials of Fire, and like a phoenix, have risen from ash. Here take the power of flame. You've earned it.";
                interactText.text = "Press X to continue";

                if (Input.GetKeyDown(KeyCode.X))
                {
                    resetSpeech();
                    // Adding Fire to inventory
                    fireStone = true;
                }
            }
        }
    }

    // Gets rid of dialog and dialog box
    void resetSpeech()
    {
        speechText.text = "";
        interactiveObj = false;
        canControl = true;
    }

    // Allows player to know when interactive character is around
    void setInteractive()
    {
        interactText.text = "Press X to interact";
    }
}