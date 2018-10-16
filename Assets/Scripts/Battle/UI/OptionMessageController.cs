using UnityEngine;
using UnityEngine.UI;

public class OptionMessageController : MonoBehaviour {

    //public static ShowMessageEvent OnNewMessage = new ShowMessageEvent();

    [SerializeField]
    Text text;
    [SerializeField]
    PanelManager panelManager;

    // Use this for initialization
    void Start()
    {
        //ShowMessageEvent.
        //OptionMessageController.OnNewMessage.AddListener(ShowMessage);
    }

    public void ShowDefaultMessage(InstancePokemonObject pokemon)
    {
        text.text = "What should " + pokemon.name + " do?";
    }

    public void ShowMessage(string message)
    {
        text.text = message;
        panelManager.ActivateMessagePanel();
    }

    public void ShowFaintMessage(InstancePokemonObject pokemon)
    {
        text.text = pokemon.name + " fainted!";
    }

    public void ShowAttackMessage(InstancePokemonObject pokemon, MoveObject move)
    {
        ShowMessage(pokemon.name + " used " + move.name + "!");
    }

}
