using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;

    // Singleton Declaration
    public static AudioManager instance;

    // Struct in C#: Variable of variables
    [System.Serializable]
    public struct Clip
    {
        public string keyName;
        public AudioClip audio;
    }
    public Clip[] clips;
    public AudioSource audioSource;

    // Background Music
    public AudioClip levelMusic;

    void Start()
    {
        mixer.SetFloat("Volume", -15f);
    }

    // Happens before start
    private void Awake()
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

    void Update()
    {

    }

    // Looks through array of clips to find the specific audio clip to play and plays it once
    public void PlayAudio(string keyName)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].keyName == keyName)
            {
                // Found clip to play
                audioSource.PlayOneShot(clips[i].audio);
                return;
            }
        }
    }

    // Change looped background theme
    public void PlayBackground(string keyName)
    {
        switch (keyName)
        {

            default:
                instance.audioSource.clip = levelMusic;
                instance.audioSource.Play();
                break;
        }

    }
}
