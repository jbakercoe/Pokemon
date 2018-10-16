using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[System.Serializable]
//public class BattleEvent : UnityEvent<InstancePokemonObject> { }

[RequireComponent(typeof(Animator))]
public class BlackAnimation : MonoBehaviour {

    /// <summary>
    /// Controls the animation of a black image to fade in and out of scenes
    /// </summary>

    public BattleEvent OnBattleStart = new BattleEvent();

    Animator anim;
    // Holds the pokemon object to be passed along to battle scripts
    InstancePokemonObject pkmn;

    void Start()
    {
        anim = GetComponent<Animator>();
        WildPokemonTrigger.OnPokemonEncounter.AddListener(FindPokemon);
    }

    public void FindPokemon(InstancePokemonObject pokemon)
    {
        print("Found a pokemon: " + pokemon.name);
        anim.SetTrigger("Battle");
        pkmn = pokemon;
    }

    public void StartBattle()
    {
        print("StartBattle()");
        OnBattleStart.Invoke(pkmn);
        anim.Play("Off");
    }

}
