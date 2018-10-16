using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class BattleEndEvent : UnityEvent { }

public class BattleEnder : MonoBehaviour {

    /// <summary>
    /// A script to Invoke the event to end a battle. 
    /// Assign listeners in inspector.
    /// </summary>

    public BattleEndEvent OnBattleEnd = new BattleEndEvent();

    public void EndBattle()
    {
        OnBattleEnd.Invoke();
    }

}
