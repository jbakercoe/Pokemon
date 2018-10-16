using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class AttackEvent : UnityEvent<InstancePokemonObject, MoveObject> { }
[System.Serializable]
public class DamageEvent : UnityEvent<int> { }
[System.Serializable]
public class FaintEvent : UnityEvent<InstancePokemonObject> { }

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Animator))]
public class BattlePokemon : MonoBehaviour {

    /// <summary>
    /// A container for a Pokemon in the battle scene.
    /// 
    /// Sets the pokemon's sprite.
    /// Attacks and takes damage.
    /// Determines when we need to faint.
    /// </summary>

    public AttackEvent OnAttack;
    public DamageEvent OnTakeDamage;
    public FaintEvent OnFaint;

    [SerializeField]
    BattlePokemon enemyBattlePokemon;
    // TODO Change
    //[SerializeField]
    //OptionMessageController messageController;
    
    public InstancePokemonObject Pokemon;

    Animator anim;
    Image image;

    void Start()
    {
        anim = GetComponent<Animator>();
        image = GetComponent<Image>();
    }

    public void SetPokemon(InstancePokemonObject pokemon)
    {
        Pokemon = pokemon;
        SetSprite(pokemon.BackSprite);
    }

    public void SetPokemon(InstancePokemonObject pokemon, bool isPlayerPokemon = true)
    {
        Pokemon = pokemon;
        SetSprite(isPlayerPokemon ? pokemon.BackSprite : pokemon.FrontSprite);
    }

    void SetSprite(Sprite sprite)
    {
        // animation should be somewhere else
        anim.Play("Base");
        image.sprite = sprite;
    }

    public void Attack(MoveObject move)
    {
        print(Pokemon.name + " used " + move.name + "!");
        OnAttack.Invoke(Pokemon, move);

        //    // TODO remove null check
        //    if(move != null)
        //    {
        //        print(Pokemon.name + " used " + move.name + "!");
        //        messageController.ShowMessage(Pokemon.name + " used " + move.name + "!");
        //        enemyBattlePokemon.TakeDamage(Pokemon, move);
        //    }
    }

    public void TakeDamage(InstancePokemonObject enemy, MoveObject move)
    {
        int damage = DamageCalculator.CalculateDamage(enemy.Level, move.Power, enemy.Attack, Pokemon.Defense);
        Pokemon.CurrentHp -= damage;
        StartCoroutine(PauseAndTakeDamage());
    }

    IEnumerator PauseAndTakeDamage()
    {
        yield return new WaitForSeconds(2f);
        anim.Play("Take Damage");
        yield return new WaitForSeconds(1f);
        OnTakeDamage.Invoke(Pokemon.CurrentHp);
        if (Pokemon.CurrentHp <= 0)
        {
            StartCoroutine(Faint());
        }
    }

    IEnumerator Faint()
    {
        yield return new WaitForSeconds(2.3f);
        anim.Play("Faint");
        OnFaint.Invoke(Pokemon);
    }

}
