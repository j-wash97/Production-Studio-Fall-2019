using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfScript : MonoBehaviour
{
    public battlerHandler mng;
    // Start is called before the first frame update
    public string clss;
    public int currentHealth;
    public int totalHealth = 5;
    public int MD = 0;
    public int PD = 3;
    public int MA = 0;
    public int PA = 4;
    public int MS = 3;
    public int AS = 3;

    //have bools for now to determine which enemy is present
    public bool wolf;
    public bool bandit;
    public bool killer;
    public bool mage;
    //have a reference to its target
    public GameObject target;

    void Start()
    {
        setUp();
        currentHealth = totalHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string displayHealth()
    {
        return currentHealth.ToString();
    }


    //public void takeDamage(int dmg)
    //{
    //    currentHealth -= dmg + PD;
    //    if(currentHealth <= 0)
    //    {
    //        currentHealth = 0;
    //    }
    //}

    public int attack()
    {
        //call the player's take damage function and pass in the wolof's attack val
        
        //mng.next();
        return PA;

    }

    public bool dead()
    {
        if(currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    //write up how the wolf will make moves
    public void makeMove()
    {
        if(true)
        {
            attack();
        }
    }

    //have a fucion to set up whatever enemy the player is fighting, is dependent on location
    public void setUp() //string location
    {
        //if the battle is in the north
        if (wolf) //location == "N"
        {
            //set up the tundra wolf stats
            clss = "Tundra Wolf";
            totalHealth = 5;
            MD = 0;
            PD = 3;
            MA = 0;
            PA = 4;
            MS = 3;
            AS = 3;
        }
        //if the battle is in the west
        else if(mage) //location == "W"
        {
            //set up the Mage Outcast Stats
            clss = "Mage Outcast";
            totalHealth = 4;
            MD = 6;
            PD = 1;
            MA = 6;
            PA = 1;
            MS = 1;
            AS = 3;
        }
        //if the battle is in the East
        else if(killer) //location ==" E"
        {
            //set up the Crazed Killer Stats
            clss = "Crazed Killer";
            totalHealth = 1;
            MD = 0;
            PD = 0;
            MA = 0;
            PA = 5;
            MS = 4;
            AS = 4;
        }
        //or if the battle is in the south
        else if(bandit) //location == "S"
        {
            //set up the Desert Bandit Stats
            clss = "Desert Bandit";
            totalHealth = 9;
            MD = 0;
            PD = 6;
            MA = 0;
            PA = 6;
            MS = 1;
            AS = 2;
        }
        //if all else fails
        else
        {
            //default to tundra wolf
            clss = "Tundra Wolf";
            totalHealth = 5;
            MD = 0;
            PD = 3;
            MA = 0;
            PA = 4;
            MS = 3;
            AS = 3;
        }
    }
}
