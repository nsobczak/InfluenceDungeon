using UnityEngine;
using System.Collections;

public class ShowPanelsBattle : MonoBehaviour
{
    #region Parameters

    public GameObject objectPanel;
    public GameObject magicPanel; 

    #endregion

    //_________________________________________________

    #region ShowFunctions

    public void ShowObjectPanel()
    {
        objectPanel.SetActive(true);
    }

    public void ShowMagicPanel()
    {
        magicPanel.SetActive(true);
    }

    #endregion


    //_________________________________________________

    #region HideFunctions

    public void HideObjectPanel()
    {
        objectPanel.SetActive(false);
    }

    public void HideMagicPanel()
    {
        magicPanel.SetActive(false);
    }

    #endregion
}