using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class characterClass : MonoBehaviour
{
    public battlerHandler mng;
    public Sprite assassin;
    public Sprite bandersnatch;
    public Sprite doctor;
    public Sprite knight;
    public Sprite monk;
    public Sprite noble;
    public Sprite witch;

    //enemy of player
    public GameObject enemy;

    //name of character

    public static string Name;

    //class of character
    public static string clss;

    //file path of the sprite
    public string fullBodyPath;

    /// The health points of a character

    public static int currentHP;

    public static int totalHP;

    /// The Magical Defense of the character

    public static int MD;

    /// The Physical Defense of the character

    public static int PD;

    /// The Magical Attack value of the character

    public static int MA;

    /// The Physical Attack value of the character

    public static int PA;

    /// The Movement Speed of the character

    public static int MS;

    /// The Attack Speed of the character 

    public static int AS;


    /// The Special Ability value of the character (0, 1, 2, +...)

    public static int SpcAbility;

    // An identifier for the character's location
    public  int location;

   

    void Start()
    {
        currentHP = totalHP;
        //setImage();
        // variables
        /*Name = ChangeScene.Name;
        clss = ChangeScene.clss;
        HP = ChangeScene.HP;
        MD = ChangeScene.MD;
        PD = ChangeScene.PD;
        MA = ChangeScene.MA;
        PA = ChangeScene.PA;
        MS = ChangeScene.MS;
        AS = ChangeScene.AS;
        SpcAbility = ChangeScene.SpcAbility;

        */
       
    }

    
    
    public void write()
    {
        Debug.Log("The name of this person is " + Name);
        Debug.Log("Their class is " + clss);
        Debug.Log("Health is " + totalHP);
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
    /// 
    /*
    public void SpecialAbility(GameObject enemy, int flag)
        {
            switch (SpcAbility)
            {
                case 0:
                    if (flag == 2 && SpcAbility == 0)
                    {
                        currentHP += 2;
                        Debug.Log(Name + " takes a quick swig of their healing potion! " + Name + " now has " + currentHP + " HP!");
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
                    opponent.currentHP -= 2;
                    }
                    break;
                default:
                    Debug.Log(Name + " analyzes their opponent and begins noticing their patterns. Their defenses grow stronger!");
                    MD++;
                    PD++;
                    break;
            }
            
        }
        */
    /*
    public void setImage()
    {
        if(clss == "Assassin")
        {
            this.GetComponent<SpriteRenderer>().sprite = assassin;
        }
        if (clss == "Beast")
        {
            this.GetComponent<SpriteRenderer>().sprite = bandersnatch;
        }
        if(clss == "Doctor")
        {
            this.GetComponent<SpriteRenderer>().sprite = doctor;
        }
        if(clss == "Knight")
        {
            this.GetComponent<SpriteRenderer>().sprite = knight;
        }
        if(clss == "Monk")
        {
            this.GetComponent<SpriteRenderer>().sprite = monk;
        }
        if(clss == "Noble")
        {
            this.GetComponent<SpriteRenderer>().sprite = noble;
        }
        if(clss == "Witch")
        {
            this.GetComponent<SpriteRenderer>().sprite = witch;
        }
    }*/
   
    public bool dead()
    {
        if(currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void takeDamage(int dmg)
    {
        currentHP -= dmg + PD; ;
        if(currentHP <= 0)
        {
            currentHP = 0;
        }
    }

    public string displayHealth()
    {
        return currentHP.ToString();
    }
    public string displayName()
    {
        return Name;
    }
    public string displayClass()
    {
        return clss;
    }

    public int attack()
    {
        return PA;  
    }

   
    //have functions to set up the stats of the character
   public void setCurrHp(int changeBy)
    {
        currentHP += changeBy;
    }

    public void setTotalHealth(int changeBy)
    {
        totalHP += changeBy;
    }

    public void setMD(int changeBy)
    {
        MD += changeBy;
    }

    public void setMA(int changeBy)
    {
        MA += changeBy;
    }

    public void setPD(int changeBy)
    {
        PD += changeBy;
    }

    public void setPA(int changeBy)
    {
        PA += changeBy;
    }

    public void setMS(int changeBy)
    {
        MS += changeBy;
    }

    public void setAS(int changeBy)
    {
        AS += changeBy;

    }

    public int showMS()
    {
        return MS;
    }

    public int showAS()
    {
        return AS;
    }

}
