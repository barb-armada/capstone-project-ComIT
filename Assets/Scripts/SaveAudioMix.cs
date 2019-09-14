using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAudioMix : MonoBehaviour
{
    private List<AudioClip> audioClipList;
    private AudioSource[] allAudioSources;    
    public void SaveMix()
    {
            
            
            audioClipList = new List<AudioClip>();
            allAudioSources = AudioSource.FindObjectsOfType<AudioSource>();


        for (int i = 0; i < allAudioSources.Length; i++)
        {
            if (allAudioSources[i].isPlaying)
            {
                audioClipList.Add(allAudioSources[i].clip);
            }
            
        }
    }

    
}