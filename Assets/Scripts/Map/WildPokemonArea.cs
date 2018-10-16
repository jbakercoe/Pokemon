using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPokemonArea : MonoBehaviour {

    [SerializeField]
    List<InstancePokemonObject> pokemon;
    [SerializeField]
    [Range(0f, .9f)]
    float findPokemonRate;

    // Get lists of all pokemon in the area of a given rarity
    List<InstancePokemonObject> veryRare = new List<InstancePokemonObject>();
    List<InstancePokemonObject> rare = new List<InstancePokemonObject>();
    List<InstancePokemonObject> semirare = new List<InstancePokemonObject>();
    List<InstancePokemonObject> common = new List<InstancePokemonObject>();
    List<InstancePokemonObject> veryCommon = new List<InstancePokemonObject>();

    void Awake()
    {
        // populate lists with pokemon of appropriate rarity
        foreach (InstancePokemonObject p in pokemon)
        {
            switch (p.Rarity)
            {
                case Rarity.VeryRare:
                    veryRare.Add(p);
                    break;
                case Rarity.Rare:
                    rare.Add(p);
                    break;
                case Rarity.Semirare:
                    semirare.Add(p);
                    break;
                case Rarity.Common:
                    common.Add(p);
                    break;
                case Rarity.VeryCommon:
                    veryCommon.Add(p);
                    break;
            }
        }
    }

    public List<InstancePokemonObject> Pokemon { get { return pokemon; } }
    public float FindPokemonRate { get { return findPokemonRate; } }

    public InstancePokemonObject PickPokemon(Rarity rarity)
    {
        switch (rarity)
        {
            case Rarity.VeryRare:
                return pickVeryRare();
            case Rarity.Rare:
                return pickRare();
            case Rarity.Semirare:
                return pickSemiRare();
            case Rarity.Common:
                return pickCommon();
            case Rarity.VeryCommon:
                return pickVeryCommon();
            default:
                return null;
        }
    }

    InstancePokemonObject pickVeryRare()
    {
        int index = getRandomPokemon(veryRare);
        if(index < 0)
        {
            return pickRare();
        } else
        {
            return veryRare[index];
        }
    }

    InstancePokemonObject pickRare()
    {
        int index = getRandomPokemon(rare);
        if (index < 0)
        {
            return pickSemiRare();
        }
        else
        {
            return rare[index];
        }
    }

    InstancePokemonObject pickSemiRare()
    {
        int index = getRandomPokemon(semirare);
        if (index < 0)
        {
            return pickCommon();
        }
        else
        {
            return semirare[index];
        }
    }

    InstancePokemonObject pickCommon()
    {
        int index = getRandomPokemon(common);
        if (index < 0)
        {
            return pickVeryCommon();
        }
        else
        {
            return common[index];
        }
    }

    InstancePokemonObject pickVeryCommon()
    {
        int index = getRandomPokemon(veryCommon);
        if (index < 0)
        {
            return null;
        }
        else
        {
            return veryCommon[index];
        }
    }

    private int getRandomPokemon(List<InstancePokemonObject> _pokemon)
    {
        if(_pokemon.Count > 0)
        {
            return Random.Range(0, _pokemon.Count);
        } else 
            return -1;
    }


}