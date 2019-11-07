using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour
{
    // The UI's text display object
    public Text turnCount;
    public Text statsList;

    // The current turn to be displayed on the UI
    private int turn = 0;

    // The character the whose attributes are to be displayed
    public characterClass character;

    // Start is called before the first frame update
    void Start()
    {
        turnCount.text = "Day " + turn;

        statsList.text = character.Name +
                       "\n\nHealth:        " + character.HP +
                         "\nSpeed:         " + character.AS +
                         "\nPhys. Attack:  " + character.PA +
                         "\nMagic Attack:  " + character.MA +
                         "\nPhys. Defense: " + character.PD +
                         "\nMagic Defense: " + character.MD;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
