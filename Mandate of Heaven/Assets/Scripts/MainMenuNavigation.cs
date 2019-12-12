using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum MenuState
{
    Title,
    CharacterSelect
}

public class MainMenuNavigation : MonoBehaviour
{
    // The current state of the menu
    [SerializeField]
    private MenuState menuState;
    // The title card menu
    public GameObject titleCard;
    // The character select menu
    public GameObject characterSelect;
    // The item that will display character stats
    public GameObject statsDisplay;
    public GameObject nameField;
    public GameObject statsList;

    // A float to control the sine wave of the title flash
    private float titleFlash;

    // The currently highlighted character
    [SerializeField]
    private GameObject focusedCharacter;
    // Tracks if the player has selected the currently displayed character
    private bool focusSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        // Set the menu to display the title card
        SetMenuState(MenuState.Title);
    }

    // Update is called once per frame
    void Update()
    {
        switch(menuState)
        {
            case MenuState.Title:
                // Transition to the character select screen when an input is given
                if (Input.anyKeyDown)
                    SetMenuState(MenuState.CharacterSelect);

                // Set the start prompt to flash on the screen
                titleFlash += Time.deltaTime * 3.0f;
                titleFlash %= 2.0f * Mathf.PI;
                Color color = titleCard.GetComponentInChildren<Text>().color;
                color.a = (Mathf.Cos(titleFlash) + 1.0f) / 2.0f;
                titleCard.GetComponentInChildren<Text>().color = color;
                break;

            case MenuState.CharacterSelect:
                // Return to the title screen if the player hits escape without the character display locked on the screen
                if (Input.GetKeyDown(KeyCode.Escape) && !focusSelected)
                    SetMenuState(MenuState.Title);
                // Unlock the character display if escape is hit while it's locked on screen
                if (Input.GetKeyDown(KeyCode.Escape) && focusSelected)
                {
                    statsDisplay.SetActive(false);
                    focusSelected = !focusSelected;
                    focusedCharacter = null;
                }
                break;
        }
    }

    /// <summary>
    /// Set the menu to the currently displayed on the screen
    /// </summary>
    /// <param name="state">The desired menu to display</param>
    void SetMenuState(MenuState state)
    {
        switch(state)
        {
            case MenuState.Title:
                characterSelect.SetActive(false);
                titleCard.SetActive(true);
                titleFlash = 0.0f;
                break;

            case MenuState.CharacterSelect:
                titleCard.SetActive(false);
                characterSelect.SetActive(true);
                statsDisplay.SetActive(false);
                focusSelected = false;
                focusedCharacter = null;
                break;
        }

        menuState = state;
    }

    public void SetFocusedCharacter(GameObject characterObj)
    {
        // If the player hasn't yet selected a character, set the specified character's stats to display on screen
        if(!focusSelected)
        {
            focusedCharacter = characterObj;
            statsDisplay.SetActive(true);
            statsDisplay.GetComponent<RectTransform>().anchoredPosition = characterObj.GetComponent<SelectionNode>().displayPosition;
            Character character = characterObj.GetComponent<SelectionNode>().character;
            nameField.GetComponent<Text>().text = character.name;
            statsList.GetComponent<Text>().text = "Health:         " + character.attributes[(int)CharacterAttribute.Health] +
                                                             "\nMovement Speed: " + character.attributes[(int)CharacterAttribute.MoveSpd] +
                                                             "\nPhys. Attack:   " + character.attributes[(int)CharacterAttribute.PhysAttk] +
                                                             "\nMagic Attack:   " + character.attributes[(int)CharacterAttribute.MagAttk] +
                                                             "\nAttack Speed:   " + character.attributes[(int)CharacterAttribute.AttkSpd] +
                                                             "\nPhys. Defense:  " + character.attributes[(int)CharacterAttribute.PhysDef] +
                                                             "\nMagic Defense:  " + character.attributes[(int)CharacterAttribute.MagDef];
        }
    }

    public void UnsetFocusedCharacter(GameObject character)
    {
        // If the specified character is the one currently highlight, but the player hasn't selected it yet, remove it from focus and remove its stats display
        if(focusedCharacter == character && !focusSelected)
        {
            focusedCharacter = null;
            statsDisplay.SetActive(false);
        }
    }

    public void SetFocusSelected(bool value) { focusSelected = value; }

    /// <summary>
    /// Submits the selected character to the data manager, finds four other characters to serve as rivals, and sends the player to the next scene
    /// </summary>
    public void BeginGame()
    {
        int[] selectedIndices = new int[5];
        int i = 0;

        // Get all characters listed from the selection
        SelectionNode[] characters = GetComponentsInChildren<SelectionNode>();
        for (int it = 0; it < selectedIndices.Length; it++)
        { selectedIndices[it] = characters.Length; }

        // Add the index of the selected character to the list of selected indices
        selectedIndices[i] = Array.IndexOf(characters, focusedCharacter.GetComponent<SelectionNode>());
        // Send this character's data to the data manager's player object
        DataManagement.instance.player = focusedCharacter.GetComponent<SelectionNode>().character;
        // If the player submitted a name into the input field, set it
        if (!String.IsNullOrEmpty(nameField.GetComponentInParent<InputField>().text))
            DataManagement.instance.player.name = nameField.GetComponentInParent<InputField>().text;

        for(i = 1; i < selectedIndices.Length; i++)
        {
            // Find the index of a character that has not already been selected
            int rngIndex;
            do {
                rngIndex = UnityEngine.Random.Range(0, characters.Length);
            } while (Array.Exists(selectedIndices, x => x == rngIndex));
            // Add the index to the list of selected indices
            selectedIndices[i] = rngIndex;

            // Add the character to the data manager as a rival
            DataManagement.instance.rivals[i - 1] = characters[rngIndex].GetComponent<SelectionNode>().character;
        }

        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
