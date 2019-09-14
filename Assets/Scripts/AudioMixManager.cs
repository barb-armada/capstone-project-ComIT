using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixManager : MonoBehaviour
{
    //private List<AudioClip> audioClipList; clip List
    protected List<AudioSource> audioClipList_name;
    private AudioSource[] audioSources_arr;
    private GameObject[] allAudioButtons_arr;

    //SaveCustomName saveCustomName;
    void Start()
    {
    }
    

    public void SaveMix() // ***saves or adds the audioclip to the "audioClipList" list
    {                     // saves or adds the audiosource to the "audioClipList_name"

        //audioClipList = new List<AudioClip>(); // creates an instance of "audioClipList" list where the audioclips 
        // that are playing are added
        audioClipList_name = new List<AudioSource>();
        
        audioSources_arr = AudioSource.FindObjectsOfType<AudioSource>(); // finds all GO of type AudioSource and stores
                                                                         // them in an array

        
        // Go through all GO and ask if there is an AudioSource component, if there is then
        // script checks whether its playing, if yes the it will add the clip on the list

        for (int x = 0; x < audioSources_arr.Length; x++)
        {
            if (audioSources_arr[x].isPlaying)
            {
                //audioClipList.Add(audioSources_arr[x].clip);
                audioClipList_name.Add(audioSources_arr[x]);
                Debug.Log("Added " + audioSources_arr[x].name);
                //int index = audioClipList.FindIndex(s => s.Equals(audioSources_arr[x]));
                //Debug.Log(index.ToString());
            }
        }
        Debug.Log(audioClipList_name.Count);

        //saveCustomName.ButtonMix(audioSources_arr);
    }

    public void DeleteMix() // stops all audiosources from playing and reverts the buttons to their original sprite
    {
        audioSources_arr = AudioSource.FindObjectsOfType<AudioSource>();
        allAudioButtons_arr = GameObject.FindGameObjectsWithTag("Audio Button");

        // Go through all GO and ask if there is an AudioSource component, if there is then
        // script checks whether its playing, if yes the it will add the clip on the list

        for (int x = 0; x < audioSources_arr.Length; x++)
        {
            if (audioSources_arr[x].isPlaying)
            {
                audioSources_arr[x].Stop();
            }
        }

        for (int y = 0; y < allAudioButtons_arr.Length; y++)
        {
            Button allButtons = allAudioButtons_arr[y].GetComponent<Button>();
            allButtons.image.overrideSprite = null;
        }

    }

    public void PlayMix()
    {
        //PlayClipAtPoint creates an audio source but automatically disposes of it once the clip has finished playing.

        for (int i = 0; i < audioClipList_name.Count; i++)
        {
            //AudioSource.PlayClipAtPoint(audioClipList[i], Vector3.zero);
            AudioSource audio = audioClipList_name[i];
            audio.Play();
            audio.loop = true;
        }
    }


}