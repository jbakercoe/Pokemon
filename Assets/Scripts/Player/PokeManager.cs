using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SendPokemonEvent : UnityEvent<InstancePokemonObject> { }

public class PokeManager : MonoBehaviour {

    public SendPokemonEvent OnSendPokemon;

    [SerializeField]
    // TODO Change to party pokemon objects
    List<InstancePokemonObject> partyPokemon;

    public InstancePokemonObject FirstPokemon { get { return partyPokemon[0]; } }

    public void SendPokemon()
    {
        OnSendPokemon.Invoke(FirstPokemon);
    }
    
}
