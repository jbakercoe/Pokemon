using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonPanelUI : MonoBehaviour {

    [SerializeField]
    Text nameText;
    [SerializeField]
    Text levelText;
    [SerializeField]
    HealthBar healthBar;
    
    public void InitializePanel(InstancePokemonObject pokemon)
    {
        nameText.text = pokemon.name;
        levelText.text = pokemon.Level.ToString();
        healthBar.SetHealth(pokemon);
    }

}
