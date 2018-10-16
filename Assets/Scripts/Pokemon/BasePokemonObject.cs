using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon/Base Pokemon")]
public class BasePokemonObject : ScriptableObject {
    
    [SerializeField]
    PokemonType primaryType;
    [SerializeField]
    PokemonType secondaryType;

    //[SerializeField]
    //List<MoveObject> moves;

    //#region Stats

    //// Stats
    //[SerializeField]
    //float hp;
    //[SerializeField]
    //float attack;
    //[SerializeField]
    //float defense;
    //[SerializeField]
    //float speed;

    //#endregion

    //private int level;

    [SerializeField]
    Sprite frontSprite;
    [SerializeField]
    Sprite backSprite;

    public Sprite FrontSprite { get { return frontSprite; } }
    public Sprite BackSprite { get { return backSprite; } }

    public PokemonType PrimaryType { get { return primaryType; } }
    public PokemonType? SecondaryType { get { return secondaryType; } }

}

public enum PokemonType
{
    Fire,
    Water,
    Grass,
    Bug,
    Ice,
    Dark,
    Dragon,
    Ghost,
    Electric,
    Rock,
    Ground,
    Normal,
    Fighting,
    Psychic,
    Poison, 
    Steel,
    Flying,
    None
}
