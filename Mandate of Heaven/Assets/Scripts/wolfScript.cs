using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfScript : MonoBehaviour
{

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

    //only used for other heroes.
    public int special;

    //have bools for now to determine which enemy is present
    public bool wolf;
    public bool bandit = false;
    public bool killer = false;
    public bool mage = false;
   

    //set up the enemy sprites
    public SpriteRenderer enemyRend;

    //determine which part of final fight its is, if it even is to being with
    public bool final1;
    public bool final2;
    public bool final3;
    public bool final4;
    public Character[] r;
    public Character g;
    void Start()
    {
        //instantiate instaance of player 
        g = DataManagement.instance.player;
        //have an array  the instances of the other characters
        r = DataManagement.instance.rivals;
        //load in the sprites for the enemy
        enemyRend = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        wolf = true;


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
        if (currentHealth <= 0)
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
        if (true)
        {
            attack();
        }
    }

    //have a fucion to set up whatever enemy the player is fighting, is dependent on location
    public void setUp() //string location
    {
        //if the battle is in the north
        if (g.location == 1 || wolf) //location == "N" location 1
        {
            //set up the tundra wolf stats
            clss = "Tundra Wolf";
            enemyRend.sprite = Resources.Load<Sprite>("Art/enemyArt/wolf_placeholder");

            totalHealth = 5;
            MD = 0;
            PD = 3;
            MA = 0;
            PA = 4;
            MS = 3;
            AS = 3;
        }
        //if the battle is in the west
        else if (g.location == 4 || mage) //location == "W" location 4
        {
            //set up the Mage Outcast Stats
            enemyRend.sprite = Resources.Load<Sprite>("Art/enemyArt/mageOutcast_placeholder");

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
        else if (g.location == 2 || killer) //location ==" E" location 2
        {
            //set up the Crazed Killer Stats
            enemyRend.sprite = Resources.Load<Sprite>("Art/enemyArt/crazedKiller_placeholder");
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
        else if (g.location == 3 || bandit) //location == "S" location 3 
        {
            //set up the Desert Bandit Stats
            enemyRend.sprite = Resources.Load<Sprite>("Art/enemyArt/desertBandit_placeholder");
            clss = "Desert Bandit";
            totalHealth = 9;
            MD = 0;
            PD = 6;
            MA = 0;
            PA = 6;
            MS = 1;
            AS = 2;
        }

        //set up our final opponents
        else if(final1 && !final2 && !final3 && !final4)
        {
            //set up the first opponent in the list
            clss = "First Hero";
            totalHealth = r[0].attributes[0];
            currentHealth = totalHealth;
            //go thru each stat and set em up
            PA =  r[0].attributes[1];
            MA = r[0].attributes[2];
            PD = r[0].attributes[3];
            MD = r[0].attributes[4];
            AS = r[0].attributes[5]; 
            MS = r[0].attributes[6];
            special = r[0].attributes[7];

        }
        else if (!final1 && final2 && !final3 && !final4)
        {
            //set up the second opponent in the list
            clss = "Second Hero";
            totalHealth = r[1].attributes[0];
            currentHealth = totalHealth;
            //go thru each stat and set em up
            PA = r[1].attributes[1];
            MA = r[1].attributes[2];
            PD = r[1].attributes[3];
            MD = r[1].attributes[4];
            AS = r[1].attributes[5];
            MS = r[1].attributes[6];
            special = r[1].attributes[7];
        }
        else if (!final1 && !final2 && final3 && !final4)
        {
            //set up the third fight
            clss = "Third Hero";
            totalHealth = r[2].attributes[0];
            currentHealth = totalHealth;
            //go thru each stat and set em up
            PA = r[2].attributes[1];
            MA = r[2].attributes[2];
            PD = r[2].attributes[3];
            MD = r[2].attributes[4];
            AS = r[2].attributes[5];
            MS = r[2].attributes[6];
            special = r[2].attributes[7];
        }
        else if (!final1 && !final2 && !final3 && final4)
        {
            //set up the fourth fight
            clss = "Fourth Hero";
            totalHealth = r[3].attributes[0];
            currentHealth = totalHealth;
            //go thru each stat and set em up
            PA = r[3].attributes[1];
            MA = r[3].attributes[2];
            PD = r[3].attributes[3];
            MD = r[3].attributes[4];
            AS = r[3].attributes[5];
            MS = r[3].attributes[6];
            special = r[3].attributes[7];
        }
        //if all else fails
        else
        {
            //default to tundra wolf
            enemyRend.sprite = Resources.Load<Sprite>("Art/enemyArt/wolf_placeholder");
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
