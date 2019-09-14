using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class SaveCustomName : MonoBehaviour
{
    public TMP_InputField inputField;
    string customName;

    public GameObject parentPanel;
    public GameObject prefabButton;

    private TextMeshProUGUI btnText;

    public AudioMixManager audioMixManager;

    public AudioSource[] myListHere;
    public void SubmitName()
    {
        if (inputField.text == "")
        {
            Debug.Log("No input detected.");
        }
        else
        {
            customName = inputField.text;
            Debug.Log("Saving " + customName);
            InstantiatePrefab(customName);
            Debug.Log("Prefab Instantiated");
            inputField.text = "";
            //SetButtonText(customName);
        }
    }
    public void InstantiatePrefab(String name)
    {
        GameObject newButton = Instantiate(prefabButton);
        newButton.transform.SetParent(parentPanel.transform, false);
        //newButton.GetComponent<Button>();

        if (name != "")
        {
            btnText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            btnText.text = name;
        }
        else
        {
            Debug.Log("no name received");
        }

        newButton.GetComponent<Button>().onClick.AddListener(audioMixManager.PlayMix);
    }

    //public void ButtonMix(AudioSource[] myList)
    //{
    //    myListHere = myList;
    //}
}

 

