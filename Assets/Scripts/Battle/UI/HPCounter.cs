using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HPCounter : MonoBehaviour {

    Text hpText;
    int totalHP;
    int _currentHP;
    
	void Start () {
        hpText = GetComponent<Text>();
	}

    public void SetHpValues(InstancePokemonObject pokemon)
    {
        totalHP = pokemon.MaxHp;
        _currentHP = pokemon.CurrentHp;
        SetHP(_currentHP, totalHP);
    }

    void SetHP(int currentHP, int maxHP)
    {
        totalHP = maxHP;
        hpText.text = currentHP + "/" + maxHP;
    }

    public void UpdateHP(int newHp)
    {
        StartCoroutine(ChangeHPText(newHp));
    }

    IEnumerator ChangeHPText(int newHp)
    {
        while(_currentHP > newHp)
        {
            _currentHP--;
            hpText.text = _currentHP + "/" + totalHP; 
            if(_currentHP == 0)
            {
                break;
            }
            yield return null;
        }
    }
	
}
