using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayer : MonoBehaviour
{
    public Character character;
    public MapDisplay mapDisplay;

    void Start()
    {
        character = DataManagement.instance.player;
        mapDisplay.character = character;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
