using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{

    // variables
    /// <summary>
    /// The name of the character
    /// </summary>
    /// 
    public InputField enterName;

    public string pName = "";

    public static string Name = "Fen";
    /// <summary>
    /// The health points of a character
    /// </summary>
    ///

    // variables
    /// <summary>
    /// The class of the Character
    /// </summary>
    /// 
    public static string clss = "";

    public int pHP = 0;
    public static int HP = 10;
    /// <summary>
    /// The Magical Defense of the character
    /// </summary>
    /// 
    public int pMD = 0;
    public static int MD = 0;
    /// <summary>
    /// The Physical Defense of the character
    /// </summary>
    /// 

    public int pPD = 0;
    public static int PD = 5;
    /// <summary>
    /// The Magical Attack value of the character
    /// </summary>
    /// 
    public int pMA = 0;
    public static int MA = 2;
    /// <summary>
    /// The Physical Attack value of the character
    /// </summary>
    /// 
    public int pPA = 0;
    public static int PA = 4;
    /// <summary>
    /// The Movement Speed of the character
    /// </summary>
    public static int MS = 5;
    /// <summary>
    /// The Attack Speed of the character 
    /// </summary>
    public static int AS = 8;

    /// <summary>
    /// The Special Ability value of the character (0, 1, 2, +...)
    /// </summary>
    public static int SpcAbility = 3;


    public void setName()
    {
        if (enterName.text == "")
        {
            return;
        }
        else
        {
            Name = enterName.text;
        }

    }

    

    public void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
