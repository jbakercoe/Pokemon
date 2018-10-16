using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveInfoSetter : MonoBehaviour {

    [SerializeField]
    Text typeText;
    [SerializeField]
    Text ppText;

    public void Refresh(MoveObject move)
    {
        typeText.text = move.Type.ToString();
        ppText.text = move.PP + "/" + move.PP;
    }

}
