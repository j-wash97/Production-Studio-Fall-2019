using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapDisplay : MonoBehaviour
{
    // The UI's text display object
    public Text turnCount;
    public Text statsList;

    // The character the whose attributes are to be displayed
    public Character character;

    // Start is called before the first frame update
    void Start()
    {
        turnCount.text = "Day " + DataManagement.instance.turn;

        statsList.text = character.name +
                       "\n\nHealth:         " + character.attributes[(int)CharacterAttribute.Health] +
                         "\nMovement Speed: " + character.attributes[(int)CharacterAttribute.MoveSpd] +
                         "\nPhys. Attack:   " + character.attributes[(int)CharacterAttribute.PhysAttk] +
                         "\nMagic Attack:   " + character.attributes[(int)CharacterAttribute.MagAttk] +
                         "\nAttack Speed:   " + character.attributes[(int)CharacterAttribute.AttkSpd] +
                         "\nPhys. Defense:  " + character.attributes[(int)CharacterAttribute.PhysDef] +
                         "\nMagic Defense:  " + character.attributes[(int)CharacterAttribute.MagDef];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
