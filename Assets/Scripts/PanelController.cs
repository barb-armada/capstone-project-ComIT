using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{   
    public void CloseOpenPanel(GameObject panelToControl)
    {
        if (panelToControl != null)
        {
            bool isActive = panelToControl.activeSelf;
            panelToControl.SetActive(!isActive);
        }
    }
}
