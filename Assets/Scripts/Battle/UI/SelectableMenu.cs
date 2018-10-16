using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ChangeSelectionEvent : UnityEvent { }

public class SelectableMenu : MonoBehaviour {

    /// <summary>
    /// For this class I will assume we're dealing with a four option menu, corner spread
    /// </summary>

    public ChangeSelectionEvent OnChangeSelection = new ChangeSelectionEvent();

    [SerializeField]
    List<Text> options;
    [SerializeField]
    int numColumns = 2;

    //Selection currentSelection;
    List<string> optionLabels = new List<string>();
    int currentOptionIndex;

	// Use this for initialization
	void Start ()
    {
        Refresh();
    }

    // Reset option labels on the menu
    public void Refresh()
    {
        foreach (Text option in options)
        {
            optionLabels.Add(option.text);
        }

        currentOptionIndex = 0;
        options[currentOptionIndex].text = "> " + optionLabels[currentOptionIndex];
        options[currentOptionIndex].GetComponent<SelectableOption>().IsSelected = true;
    }

    // Update is called once per frame
    void Update () {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Check if we can move to the right
            if (options[currentOptionIndex].GetComponent<SelectableOption>().isLeft)
            {
                int targetIndex = currentOptionIndex + 1;
                GetNewSelection(targetIndex);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Check if we can move to the left
            if (!options[currentOptionIndex].GetComponent<SelectableOption>().isLeft)
            {
                int targetIndex = currentOptionIndex - 1;
                GetNewSelection(targetIndex);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Check if we can move up
            if (!options[currentOptionIndex].GetComponent<SelectableOption>().isTop)
            {
                int targetIndex = currentOptionIndex - numColumns;
                GetNewSelection(targetIndex);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Check if we can move down
            if (options[currentOptionIndex].GetComponent<SelectableOption>().isTop)
            {
                int targetIndex = currentOptionIndex + numColumns;
                GetNewSelection(targetIndex);
            }
        }        
    }

    void GetNewSelection(int index)
    {
        resetTextOptions();
        options[index].text = "> " + optionLabels[index];
        options[currentOptionIndex].GetComponent<SelectableOption>().IsSelected = false;
        currentOptionIndex = index;
        options[currentOptionIndex].GetComponent<SelectableOption>().IsSelected = true;
    }

    void resetTextOptions()
    {
        for(int i = 0; i < options.Count; i++)
        {
            options[i].text = optionLabels[i];
        }
    }

}
