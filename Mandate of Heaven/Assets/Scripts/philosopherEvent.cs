using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class philosopherEvent : MonoBehaviour
{
    public characterClass chrctr;
    //have some strings to give player identifying info abt event
    string description = "You are travelling along a road when you suddenly overhear a fierce verbal debate from afar. Coming upon two wise men nearly brought to fisticuffs, you listen for awhile before discovering that each has a wildly different take on the best form of warfare. They ask you to pass final judgement on who best argues their case. Will you agree with the Scholar of Mages, the Scholar of Knights, disagree with both and posit a healthy fighting-free lifestyle, or ignore them and hurry on your way?";
    string sideMage = "Side with the Scholar of Mages";
    string sideKnight = "Side with the Scholar of Knights";
    string ignore = "Side with neither";
    string leave = "Leave";
    //have some strings to describe what happens next
    string mageChoice = "You side with the Scholar of Mages, positing a way of war reliant upon the advanced understanding of the arcane, to wreak diverse and devastating effects upon the battlefield. The scholar of Mages, gives you a polite smile and a curt nod, stating that he is glad to have met someone who understands the useful and fine nature of magic. You gain +1 Magic Attack and +1 Magic Defense";
    string knightChoice = "You side with the Scholar of Knights, positing a way of war reliant upon the tested and true strength of manpower, martial prowess, tactics, and fighting spirit. The Scholar of Knights lets out a hearty laugh, slaps you on the back, and states that he is glad to have met another person of culture. You gain +1 Physical Attack and +1 Physical Defense.";
    string neitherChoice = "You side with neither scholar, instead positing a healthy lifestyle free from fighting. The two scholars look perplexed, but have at least stopped quarreling in their attempt to rationalize what they heard. You gain an extra 2 Health Points.";
    string abandon = "You decide to leave. Idealistic disputes are just not your thing.";

    //have a string as a result
    string result;
    public void choose(int choiceNum)
    {
        switch (choiceNum)
        {
            case 1:
                result = mageChoice;
                chrctr.setMA(1);
                chrctr.setMD(1);
                break;
            case 2:
                result = knightChoice;
                chrctr.setPA(1);
                chrctr.setPD(1);
                break;
            case 3:
                result = neitherChoice;
                characterClass.currentHP += 2;
                characterClass.totalHP += 2;
                break;
            case 4:
                result = abandon;
                break;
            default:

                break;
        }
    }

    public string descr()
    {
        return description;
    }

    public string sideWithMage()
    {
        return sideMage;
    }

    public string sideWithKnight()
    {
        return sideKnight;
    }

    public string sideWithNeither()
    {
        return ignore;
    }

    public string leaveThemBoth()
    {
        return leave;
    }

    public string mageChosenDescr()
    {
        return mageChoice;
    }

    public string knightChosenDescr()
    {
        return knightChoice;
    }

    public string neitherChosenDescr()
    {
        return neitherChoice;
    }

    public string abandonDescr()
    {
        return abandon;
    }

    public string resultText()
    {
        return result;
    }
}
