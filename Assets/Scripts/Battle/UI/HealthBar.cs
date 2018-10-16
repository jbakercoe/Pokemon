using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField]
    BattlePokemon battlePokemon;

    Slider slider;
    int moveSpeed = 1;

    void OnEnable()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(int newHP)
    {
        if (slider == null)
            slider = GetComponent<Slider>();

        StartCoroutine(DrainHealthBar(newHP));
    }

    IEnumerator DrainHealthBar(int newHP)
    {
        while (slider.value > newHP)
        {
            slider.value--;
            yield return null;
        }
    }

    public void SetHealth(InstancePokemonObject pokemon)
    {
        slider.maxValue = pokemon.MaxHp;
        slider.value = pokemon.CurrentHp;
    }

}
