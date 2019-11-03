using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfEvent : MonoBehaviour
{
    
    //have some strings to introduce you to the event
    string description = "You see before you a ravenous group of wolves";
    string fight = "Prepare to fight!";
    string flee = "Run!";

    //have some strings for the text of the buttons
    string fightChoice = "You prepare yourself for combat!";
    string fleeChoice = "You flee from the ravenous pack of wolves.";

    public string descr()
    {
        return description;
    }

    public string fightButn()
    {
        return fight;
    }

    public string fleeButn()
    {
        return flee;
    }

    public string fightDescr()
    {
        return fightChoice;
    }

    public string fleeDescr()
    {
        return fleeChoice;
    }
}
