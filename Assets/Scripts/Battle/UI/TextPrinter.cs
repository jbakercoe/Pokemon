using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ProceedEvent : UnityEvent { }

[System.Serializable]
public class ShowMessageEvent : UnityEvent<string> { }

public class TextPrinter : MonoBehaviour {

    bool isPrinting;

    public bool IsPrinting { get { return isPrinting; } }
    public ProceedEvent OnProceed;

    [SerializeField]
    Text text;
    [SerializeField]
    [Range(1, 10)]
    [Tooltip("Lower number means faster text")]
    int numFrames;

    bool isReadyToProceed;
    
    //public void PlayText(string _name)
    //{
    //    string newText = "A wild " + _name + " appears!";
    //    StartCoroutine(ShowText(newText));
    //}

    public void Print(string text)
    {
        StartCoroutine(ShowText(text));
    }

    IEnumerator ShowText(string _text)
    {
        text.text = "";

        isPrinting = true;

        foreach(char c in _text)
        {
            text.text += c;
            for(int i = 0; i < 2; i++)
            {
                yield return null;
            }
        }
        isPrinting = false;
        isReadyToProceed = true;
    }

    public void Proceed()
    {
        OnProceed.Invoke();
    }
	
}
