using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterClass : MonoBehaviour
{
    //name of character

    public string Name;

    //class of character
    public string clss;

    /// The health points of a character

    public int HP;

    /// The Magical Defense of the character

    public int MD;

    /// The Physical Defense of the character

    public int PD;

    /// The Magical Attack value of the character

    public int MA;

    /// The Physical Attack value of the character

    public int PA;

    /// The Movement Speed of the character

    static public int MS;

    /// The Attack Speed of the character 

    public int AS;


    /// The Special Ability value of the character (0, 1, 2, +...)

    public int SpcAbility;



    void Start()
    {
        // variables
        Name = ChangeScene.Name;
        clss = ChangeScene.clss;
        HP = ChangeScene.HP;
        MD = ChangeScene.MD;
        PD = ChangeScene.PD;
        MA = ChangeScene.MA;
        PA = ChangeScene.PA;
        MS = ChangeScene.MS;
        AS = ChangeScene.AS;
        SpcAbility = ChangeScene.SpcAbility;

        

    }
    
    public void write()
    {
        Debug.Log("The name of this person is " + Name);
        Debug.Log("Their class is " + clss);
        Debug.Log("Health is " + HP);
        Debug.Log("Magic Defense is " + MD);
        Debug.Log("Physical Defense is " + PD);
        Debug.Log("Magic Attack is "+ MA);
        Debug.Log("Physical Attack is " + PA);
        Debug.Log("Movement Speed is " + MS);
        Debug.Log("Attack Speed is " + AS);


    }




    void Update()
        {
        
        }

    /// <summary>
    /// This character's special ability
    /// May be performed at (0) Own Turn, (1) Opponent Turn, or (2) Stalemate [SpcAbility]
    /// [int flag] will indicate what the current stage of combat is to inform 
    /// </summary>
    /// <param name="opponent"></param>
    public void SpecialAbility(characterClass opponent, int flag)
        {
            switch (SpcAbility)
            {
                case 0:
                    if (flag == 2 && SpcAbility == 0)
                    {
                        HP += 2;
                        Debug.Log(Name + " takes a quick swig of their healing potion! " + Name + " now has " + HP + " HP!");
                    }
                    break;
                case 1:
                    if (flag == 0 && SpcAbility == 1)
                    {
                        Debug.Log(Name + " suddenly switches up their style and begins moving differently!");
                        int holder = 0;
                        holder = AS;
                        AS = MS;
                        MS = holder;
                    }
                    break;
                case 2:
                    if (flag == 1 && SpcAbility == 2)
                    {
                        Debug.Log(Name + " makes a reckless counter attack and lands a glancing blow on " + opponent.Name + "!");
                        opponent.HP -= 2;
                    }
                    break;
                default:
                    Debug.Log(Name + " analyzes their opponent and begins noticing their patterns. Their defenses grow stronger!");
                    MD++;
                    PD++;
                    break;
            }
        }



    

}
