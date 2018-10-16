using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pokemon", menuName = "Pokemon/Wild Pokemon")]
public class InstancePokemonObject : ScriptableObject {

    [SerializeField]
    BasePokemonObject basePokemon;
    [SerializeField]
    Rarity rarity;
    [SerializeField]
    int level;

    [SerializeField]
    List<MoveObject> moves;

    public int MaxHp;
    public int CurrentHp;
    public int Attack;
    public int Defense;
    public int Speed;


    public Sprite FrontSprite { get { return basePokemon.FrontSprite; } }
    public Sprite BackSprite { get { return basePokemon.BackSprite; } }
    public Rarity Rarity { get { return rarity; } }
    public int Level { get { return level; } }
    public List<MoveObject> Moves { get { return moves; } }

}

public enum Rarity
{
    VeryCommon,
    Common,
    Semirare,
    Rare,
    VeryRare
}
