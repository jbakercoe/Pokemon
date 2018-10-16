using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    North,
    South,
    East,
    West
}


[System.Serializable]
public class InputEvent : UnityEvent<Direction> { }

public class DirectionInputReader : MonoBehaviour {

    public InputEvent inputEvent;

    Vector2 input;
    bool isLookingForInput = true;

    void Start()
    {
        WildPokemonTrigger.OnPokemonEncounter.AddListener(Disable);
    }

    // Update is called once per frame
    void Update () {
        if(isLookingForInput)
            CheckForUserInput();
    }

    public void Enable()
    {
        isLookingForInput = true;
    }

    // Parameter to match event
    public void Disable(InstancePokemonObject pkmn = null)
    {
        isLookingForInput = false;
    }

    private void CheckForUserInput()
    {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                input.y = 0;
            }
            else
            {
                input.x = 0;
            }

        if (input != Vector2.zero)
        {
            inputEvent.Invoke(CheckDirection(input));
        }
            
    }

    private Direction CheckDirection(Vector2 _input)
    {
        if (_input.x > 0)
        {
            // East
            return Direction.East;
        }
        else if (_input.x < 0)
        {
            // West
            return Direction.West;
        }
        else if (_input.y > 0)
        {
            // North
            return Direction.North;
        }
        else
        {
            // South
            return Direction.South;
        }
        
    }

}
