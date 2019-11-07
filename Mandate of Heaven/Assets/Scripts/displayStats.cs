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
        nameText.text = "Name: " + characterClass.Name;
        clssText.text = "Class: " + characterClass.clss;
        hpText.text = "Health: " + characterClass.currentHP + "/" + characterClass.totalHP;
    }
}
