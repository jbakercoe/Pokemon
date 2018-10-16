using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveListMaker : MonoBehaviour {
    
    public void SetMoveList(InstancePokemonObject pokemon)
    {
        MoveHolder[] moveLabels = GetComponentsInChildren<MoveHolder>();
        List<MoveObject> moves = pokemon.Moves;

        while(moves.Count < moveLabels.Length)
        {
            moves.Add(null);
        }

        for (int i = 0; i < moveLabels.Length; i++)
        {
            moveLabels[i].SetMove(moves[i]);
        }
    }

}
