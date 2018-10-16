using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class UseMoveEvent : UnityEvent<MoveObject> { }

[RequireComponent(typeof(Text))]
public class MoveHolder : MonoBehaviour {

    /// <summary>
    /// This script goes on the text item that holds the move
    /// </summary>

    public UseMoveEvent OnUseMove;

    [HideInInspector]
    public bool ContainsMove;
    
    MoveObject move;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void UseMove()
    {
        if(move != null)
            OnUseMove.Invoke(move);
    }

    public void SetMove(MoveObject _move)
    {

        // TODO extract
        if(text == null)
        {
            text = GetComponent<Text>();
        }
        
        if(_move != null)
        {
            move = _move;
            text.text = move.name;
            ContainsMove = true;
        } else
        {
            move = null;
            text.text = "----";
            ContainsMove = false;
        }
    }

}
