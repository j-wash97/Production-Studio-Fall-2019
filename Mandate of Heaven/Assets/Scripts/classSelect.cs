using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class classSelect : MonoBehaviour
{
    public GameObject player;
    public characterClass mng;

    public InputField enterName;

    public string clss = "";

    //class beast
    public void setClassBeast()
    {
        characterClass.clss = "Beast";
        //total hp is 4
        characterClass.totalHP = 4;
        //Magic defense is 2
        player.GetComponent<characterClass>().setMD(2);
        //physical defense is 2;
        player.GetComponent<characterClass>().setPD(2);
        //magic attack is 2
        player.GetComponent<characterClass>().setMA(2);
        //physical attack is 2
        player.GetComponent<characterClass>().setPA(2);
        //movement speed is 4
        player.GetComponent<characterClass>().setMS(4);
        //attack speed is 4
        player.GetComponent<characterClass>().setAS(4);
    }

    public void setClassNoble()
    {
        characterClass.clss = "Noble";
        characterClass.totalHP = 6;
        //Magic defense is 6
        player.GetComponent<characterClass>().setMD(6);
        //physical defense is 6
        player.GetComponent<characterClass>().setPD(6);
        //magic attack is 6
        player.GetComponent<characterClass>().setMA(6);
        //physical attack is 6
        player.GetComponent<characterClass>().setPA(6);
        //movement speed is 1
        player.GetComponent<characterClass>().setMS(1);
        //attack speed is 1
        player.GetComponent<characterClass>().setAS(1);
    }

    public void setClassAssassin()
    {
        characterClass.clss = "Assassin";
        characterClass.totalHP = 2;
        
        //Magic defense is 1
        player.GetComponent<characterClass>().setMD(1);
        //physical defense is 1
        player.GetComponent<characterClass>().setPD(1);
        //magic attack is 0
        player.GetComponent<characterClass>().setMA(0);
        //physical attack is 5
        player.GetComponent<characterClass>().setPA(5);
        //movement speed is 3
        player.GetComponent<characterClass>().setMS(3);
        //attack speed is 6
        player.GetComponent<characterClass>().setAS(6);

 
    }

    public void setClassWitch()
    {
        characterClass.clss = "Witch";
        characterClass.totalHP = 3;

        //Magic defense is 4
        player.GetComponent<characterClass>().setMD(4);
        //physical defense is 0
        player.GetComponent<characterClass>().setPD(0);
        //magic attack is 8
        player.GetComponent<characterClass>().setMA(8);
        //physical attack is 0
        player.GetComponent<characterClass>().setPA(0);
        //movement speed is 2
        player.GetComponent<characterClass>().setMS(2);
        //attack speed is 5
        player.GetComponent<characterClass>().setAS(5);

    }

    public void setClassKnight()
    {
        characterClass.clss = "Knight";
        characterClass.totalHP = 10;

        //Magic defense is 2
        player.GetComponent<characterClass>().setMD(2);
        //physical defense is 6
        player.GetComponent<characterClass>().setPD(6);
        //magic attack is 0
        player.GetComponent<characterClass>().setMA(0);
        //physical attack is 3
        player.GetComponent<characterClass>().setPA(3);
        //movement speed is 2
        player.GetComponent<characterClass>().setMS(2);
        //attack speed is 3
        player.GetComponent<characterClass>().setAS(3);
    }

    public void setClassDoc()
    {
        characterClass.clss = "Doctor";
        characterClass.totalHP = 9;

        //Magic defense is 2
        player.GetComponent<characterClass>().setMD(2);
        //physical defense is 2;
        player.GetComponent<characterClass>().setPD(2);
        //magic attack is 1
        player.GetComponent<characterClass>().setMA(1);
        //physical attack is 4
        player.GetComponent<characterClass>().setPA(4);
        //movement speed is 3
        player.GetComponent<characterClass>().setMS(3);
        //attack speed is 3
        player.GetComponent<characterClass>().setAS(3);

    }
    public void setClassMonk()
    {
        characterClass.clss = "Monk";
       characterClass.totalHP = 5;

        //Magic defense is 4
        player.GetComponent<characterClass>().setMD(4);
        //physical defense is 3
        player.GetComponent<characterClass>().setPD(3);
        //magic attack is 2
        player.GetComponent<characterClass>().setMA(2);
        //physical attack is 1
        player.GetComponent<characterClass>().setPA(1);
        //movement speed is 6
        player.GetComponent<characterClass>().setMS(6);
        //attack speed is 1
        player.GetComponent<characterClass>().setAS(1);

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
