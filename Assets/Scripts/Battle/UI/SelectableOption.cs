using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ClickEvent : UnityEvent { }

public class SelectableOption : MonoBehaviour, ISelectable {

    /// <summary>
    /// Assumed to be part of a four option menu. Corner spread.
    /// </summary>

    public ClickEvent clickEvent;
    public bool isTop;
    public bool isLeft;

    [HideInInspector]
    public bool IsSelected;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsSelected)
        {
            OnSelect();
        }
    }

    public void OnSelect()
    {
        clickEvent.Invoke();
    }

}
