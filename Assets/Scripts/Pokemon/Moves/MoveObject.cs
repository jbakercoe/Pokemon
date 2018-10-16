using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Pokemon/Move")]
public class MoveObject : ScriptableObject {

    [SerializeField]
    int power;
    [SerializeField]
    int pp;
    [SerializeField]
    int accuracy;
    [SerializeField]
    PokemonType type;

    public int Power {  get { return power; } }
    public int PP { get { return pp; } }
    public int Accuracy { get { return accuracy; } }
    public PokemonType Type { get { return type; } }

}
