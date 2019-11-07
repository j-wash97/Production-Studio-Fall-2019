using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class classSelect : MonoBehaviour
{
    public GameObject player;

    public InputField enterName;

    public string clss = "";

    public void setClassBeast()
    {
        characterClass.clss = "Beast";
        characterClass.totalHP = 4;
        characterClass.MD = 2;
        characterClass.PD = 2;
        characterClass.MA = 2;
        characterClass.PA = 2;
        characterClass.MS = 4;
        characterClass.AS = 4;
    }

    public void setClassNoble()
    {
        characterClass.clss = "Noble";
        characterClass.totalHP = 6;
        characterClass.MD = 6;
        characterClass.PD = 6;
        characterClass.MA = 6;
        characterClass.PA = 6;
        characterClass.MS = 1;
        characterClass.AS = 1;
    }

    public void setClassAssassin()
    {
        characterClass.clss = "Assassin";
        characterClass.totalHP = 2;
        characterClass.MD = 1;
        characterClass.PD = 1;
        characterClass.MA = 0;
        characterClass.PA = 5;
        characterClass.MS = 3;
        characterClass.AS = 6;
    }

    public void setClassWitch()
    {
        characterClass.clss = "Witch";
        characterClass.totalHP = 3;
        characterClass.MD = 4;
        characterClass.PD = 0;
        characterClass.MA = 8;
        characterClass.PA = 0;
        characterClass.MS = 2;
        characterClass.AS = 5;
    }

    public void setClassKnight()
    {
        characterClass.clss = "Knight";
        characterClass.totalHP = 10;
        characterClass.MD = 2;
        characterClass.PD = 6;
        characterClass.MA = 0;
        characterClass.PA = 3;
        characterClass.MS = 2;
        characterClass.AS = 3;
    }

    public void setClassDoc()
    {
        characterClass.clss = "Doctor";
        characterClass.totalHP = 9;
        characterClass.MD = 2;
        characterClass.PD = 2;
        characterClass.MA = 1;
        characterClass.PA = 4;
        characterClass.MS = 3;
        characterClass.AS = 3;
    }
    public void setClassMonk()
    {
        characterClass.clss = "Monk";
       characterClass.totalHP = 5;
        characterClass.MD = 4;
        characterClass.PD = 3;
        characterClass.MA = 2;
        characterClass.PA = 1;
        characterClass.MS = 6;
        characterClass.AS = 1;
    }

    public void setName()
    {
        if (enterName.text == "")
        {
            characterClass.Name = clss;
        }
        else
        {
            characterClass.Name = enterName.text;
        }

    }
}
