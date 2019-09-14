using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AudioManager : MonoBehaviour
{ 
    Sprite spriteOnPlay;
    Button audioButton;
    bool isPlaying;
    
    AudioSource buttonAudiosource;
    Button buttonSprite;

    
    void Start()
    {
        gameObject.AddComponent<AudioSource>(); // adds the AudioSource component and loads audio to each GO the script is attached to
        buttonAudiosource = gameObject.GetComponent<AudioSource>();
        buttonAudiosource.clip = Resources.Load<AudioClip>(gameObject.name);

        gameObject.GetComponent<Image>(); //returns the Image component of each GO and loads "spriteOnPlay" to each  
        spriteOnPlay = Resources.Load<Sprite>(gameObject.name);

        audioButton = gameObject.GetComponent<Button>(); // returns te Button component to allow access to image properties
        
    }
    public void PlayStopAudio()
    {
        // plays and stops the audio when button is clicked

        if (!isPlaying)
        {
            audioButton.image.overrideSprite = spriteOnPlay;
            buttonAudiosource.Play();
            buttonAudiosource.loop = true;
            isPlaying = true;
        }
        else
        {
            audioButton.image.overrideSprite = null;
            buttonAudiosource.Stop();
            isPlaying = false;
        }

    }
}
