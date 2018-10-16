using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    [SerializeField]
    GameObject messagePanel;
    [SerializeField]
    GameObject optionObject;
    [SerializeField]
    GameObject movesObject;
    
    public void ActivateMessagePanel()
    {
        messagePanel.SetActive(true);
        optionObject.SetActive(false);
        movesObject.SetActive(false);
    }

    public void ActivateOptionPanel()
    {
        messagePanel.SetActive(false);
        optionObject.SetActive(true);
        movesObject.SetActive(false);
    }
    public void ActivateMovesPanel()
    {
        messagePanel.SetActive(false);
        optionObject.SetActive(false);
        movesObject.SetActive(true);
    }

}
