using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class displayStats : MonoBehaviour
{
    public Text nameText;
    public Text clssText;
    public Text hpText;

    public void display()
    {
        nameText.text = "Name: " + ChangeScene.Name;
        clssText.text = "Class: " + ChangeScene.clss;
        hpText.text = "Health: " + ChangeScene.HP;
    }
}
