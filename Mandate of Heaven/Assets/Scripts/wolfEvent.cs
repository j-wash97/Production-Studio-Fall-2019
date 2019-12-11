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

    string result;
    public void choose(int index)
    {
        switch (index)
        {
            case 1:
                result = fightChoice;
                break;
            case 2:
                result = fleeChoice;
                break;


            default:

                break;
        }

    }

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

    public string resultTxt()
    {
        return result;
    }
}
