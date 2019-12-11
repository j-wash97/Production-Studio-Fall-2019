using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chickenEvent : MonoBehaviour
{
    public characterClass chrctr;
    //have some strings to introduce you to the event
    string description = "You arrive in a small settlement. As you take a look at your surroundings you notice a crying child, a broken pen made from twigs, and a loose chicken that is making its way down the settlement's main road.";
    string chase = "Catch the chicken (Requires 4 MS and 4 AS).";
    string leave = "Leave the crying child and the chicken on the lamb alone";

    //have some strings to describe how the events turn out
    string failure = "You race after the chicken, as fast as your body will allow you, but as your feet speed up they catch a pothole in the road, and you fall over. The chicken escapes into the edge of the wilderness outside of the settlement.";
    string succeed = "You race after the chicken, and like a bat out of hell you close in on it, its clucking intensifying in surprise, and growing even greater as you manage to catch it and pick it up. You deliver the feisty flightless bird to the crying young child you saw by the broken pen, and they explain to you that they had accidentally broke it, leading to the chicken's escape. They thank you and reward you.";
    string leaveChild = "You ignore the crying child and the plucky poultry, you have more important things to concern yourself with.";

    //have one string be the final result
    string result;
    public void choose(int index)
    {
        switch (index)
        {
            case 1:
                if (chrctr.showMS() < 4 || chrctr.showAS() < 4)
                {
                    result = failure;

                }
                else
                {
                    result = succeed;

                }
                break;
            case 2:
                result = leaveChild;
                break;

            default:

                break;
        }

    }




    //have several functions just to return strings
    public string chaseChicken()
    {
        return chase;
    }
    public string leaveChld()
    {
        return leave;
    }
    public string descr()
    {
        return description;
    }
    public string fail()
    {
        return failure;
    }
    public string success()
    {
        return succeed;
    }
    public string leaveTheChild()
    {
        return leaveChild;
    }

    public string resultText()
    {
        return result;
    }
}
