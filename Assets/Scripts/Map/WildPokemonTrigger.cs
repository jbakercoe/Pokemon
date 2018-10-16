using UnityEngine;
using UnityEngine.Events;

public class PokeBattleEvent : UnityEvent<InstancePokemonObject> { }

//[RequireComponent(typeof(BoxCollider2D))]
public class WildPokemonTrigger : MonoBehaviour {

    public static PokeBattleEvent OnPokemonEncounter = new PokeBattleEvent();

    [SerializeField]
    WildPokemonArea area;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FindWildPokemon.CheckForWildPokemon(area.FindPokemonRate))
            {
                Rarity rarity = FindWildPokemon.DetermineRarity();
                InstancePokemonObject pokemon = area.PickPokemon(rarity);
                OnPokemonEncounter.Invoke(pokemon);
            }
        }
    }

}
