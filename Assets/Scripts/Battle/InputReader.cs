using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SubmitEvent : UnityEvent { }

public class InputReader : MonoBehaviour {

    public SubmitEvent OnSubmit;

    bool isEnabled = true;

    void Update()
    {
        if (isEnabled)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                OnSubmit.Invoke();
            }
        }
    }

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }

}
