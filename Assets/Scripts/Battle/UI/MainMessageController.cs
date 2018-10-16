using UnityEngine;

[RequireComponent(typeof(TextPrinter))]
public class MainMessageController : MonoBehaviour {

    TextPrinter textPrinter;

    void Start()
    {
        textPrinter = GetComponent<TextPrinter>();
    }

    public void ShowEncounterMessage(InstancePokemonObject pokemon)
    {
        textPrinter.Print("A wild " + pokemon.name + " appeared!");
    }

    public void ShowFaintMessage(InstancePokemonObject pokemon)
    {
        textPrinter.Print(pokemon.name + " fainted!");
    }

    public void ShowAttackMessage(InstancePokemonObject pokemon, MoveObject move)
    {
        textPrinter.Print(pokemon.name + " used " + move.name + "!");
    }

    public void ShowRunMessage()
    {
        textPrinter.Print("Got away safely!");
    }
}
