using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class BattleEvent : UnityEvent<InstancePokemonObject> { }

public class BattleGUIManager : MonoBehaviour {

    public BattleEvent OnBattleStart;

    [SerializeField]
    CameraSwitcher cameraSwitcher;
    [SerializeField]
    TextPrinter messageText;
    [SerializeField]
    PokemonPanelUI playerUI;
    [SerializeField]
    PokemonPanelUI enemyUI;
    [SerializeField]
    BattlePokemon enemyPokemon;

    PokeManager pokeManager;

	// Use this for initialization
	void Start () {
        //WildPokemonTrigger.StartBattle.AddListener(StartBattle);
        pokeManager = FindObjectOfType<PokeManager>();
	}

    public void StartBattle(InstancePokemonObject pokemon)
    {
        OnBattleStart.Invoke(pokemon);
        cameraSwitcher.EnterBattle();
        //messageText.PlayText(pokemon.name);
        // TODO make these 2 listeners to OnBattleStart
        enemyUI.InitializePanel(pokemon);
        enemyPokemon.SetPokemon(pokemon, false);
        pokeManager.SendPokemon();
    }

}
