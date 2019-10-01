using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class classSelect : MonoBehaviour
{
    public string clss = "";

    public void setClassBeast()
    {
        ChangeScene.clss = "Beast";
        ChangeScene.HP = 4;
    }

    public void setClassNoble()
    {
        ChangeScene.clss = "Noble";
        ChangeScene.HP = 6;
    }

    public void setClassAssassin()
    {
        ChangeScene.clss = "Assassin";
        ChangeScene.HP = 2;
    }

    public void setClassWitch()
    {
        ChangeScene.clss = "Witch";
        ChangeScene.HP = 3;
    }

    public void setClassKnight()
    {
        ChangeScene.clss = "Knight";
        ChangeScene.HP = 10;
    }

    public void setClassDoc()
    {
        ChangeScene.clss = "Doctor";
        ChangeScene.HP = 9;
    }
    public void setClassMonk()
    {
        ChangeScene.clss = "Monk";
        ChangeScene.HP = 5;
    }
}
