using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // Singleton Declaration
    public static CutsceneManager instance;

    // UI Variables
    //public Text speechText;
    //public Text interactText;
    //public Image img;

    bool isImgOn;
    bool interactiveObj;

    void Awake()
    {
        // Prevents there from being more than one Audio Manager
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Prevents from being destroyed when loading new scene
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    void Start()
    {
        // Text
        //speechText.text = "";

        // Speech Box Background
        //img.enabled = true;
        //isImgOn = true;

        // Set Speech Box Inactive
        //interactiveObj = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Determines if speech box will appear if character initiates interaction
        /*
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
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        // Empty Object with "Fire Elemental" Tag is interacting with player
        if (other.gameObject.CompareTag("Fire Elemental"))
        {
            /*
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
            }*/
        }
    }

    // Gets rid of dialog and dialog box
    /*
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
    }*/


}
