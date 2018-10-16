using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    Camera battleCamera;

    [SerializeField]
    bool testBattleCam;

	// Use this for initialization
	void Start () {
        
        if (testBattleCam)
        {
        } else
        {
            mainCamera.gameObject.SetActive(true);
            battleCamera.gameObject.SetActive(false);
        }

	}

    public void EnterBattle()
    {
        mainCamera.gameObject.SetActive(false);
        battleCamera.gameObject.SetActive(true);
    }

    public void ExitBattle()
    {
        mainCamera.gameObject.SetActive(true);
        battleCamera.gameObject.SetActive(false);
    }

}
