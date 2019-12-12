using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class battlerHandler : MonoBehaviour
{
    //
    public enum stateOfBattle
    {
        START,
        STANDBY,
        PLAYERCH,
        ENEMCH,
        LOSE,
        WIN
    }

    public stateOfBattle currState;

    //public ui elements to set up player choice as well as displaying info about the enemy turn
    public Text wolfInfo;
    public Text playerHealth;
    public Text playerName;
    public Text playerClass;
    public Text status;
    public Button attackBtn;
    public Button defendBtn;
    public Button specialBtn;
    public Button fleeBtn;


    //btn for going to the next page/ descr in the info canvas
    public Button nextBtn;

    //game objects of the player and wolf
    public GameObject player;
    public GameObject enemy;

    public bool playerTurn;
    public bool enemTurn;
    public bool endCombat;
    public bool playerV;

    //status that updates the text in the info canvas
    public string st;

    //have an int modifier that modifies and allows the enemy and players to defend
    //maybe add to individual scrpts, one to character class and the other to wolf scrpt
    public int enemDefenseMod;
    public int playerDefenseMod;

    //
    public GameObject playerDecInfo;


    //have  a public variable to record the damage done 
    public int playerLethality;

    //location of battle
    public int loc;
    
    // Start is called before the first frame update
    void Start()
    {

        
        //always start in start
        currState = stateOfBattle.START;
        displayCombatantInfo();
        setUPUI();
        /*
        
        playerTurn = true;
        enemTurn = false;
        endCombat = false; */
        loc = this.gameObject.GetComponent<DataManagement>().player.location;

    }

    // Update is called once per frame
    void Update()
    {
        isDead();

        //switch(currState)
        //{
        //    case (stateOfBattle.START):

        //        break;
        //    case (stateOfBattle.PLAYERCH):
        //        //always update UI
        //        setUPUI();
        //        //also always update combatant info
        //        displayCombatantInfo();
        //        break;
        //    case (stateOfBattle.ENEMCH):
        //        //always update UI
        //        setUPUI();
        //        //also always update combatant info
        //        displayCombatantInfo();
        //        break;
        //    case (stateOfBattle.LOSE):
        //        //always update UI
        //        setUPUI();
        //        //also always update combatant info
        //        displayCombatantInfo();
        //        break;
        //    case (stateOfBattle.WIN):
        //        //always update UI
        //        setUPUI();
        //        //also always update combatant info
        //        displayCombatantInfo();
        //        break;
        //}
        /*
        //combat loop
        while(!endCombat)
        {
            //check all thorughout combat to see if the fight is over
            isDead();
            if(playerTurn && !enemTurn)
            {
                attackBtn.gameObject.SetActive(true);
                defendBtn.gameObject.SetActive(true);
                specialBtn.gameObject.SetActive(true);
                fleeBtn.gameObject.SetActive(true);
            }
            else
            {
                attackBtn.gameObject.SetActive(false);
                defendBtn.gameObject.SetActive(false);
                specialBtn.gameObject.SetActive(false);
                fleeBtn.gameObject.SetActive(false);
            }

        }*/
    }

    public void isDead()
    {
        //if player has lost, set state to appropriate
        if (player.GetComponent<characterClass>().dead() == true)
        {
            currState = stateOfBattle.LOSE;
        }
        if (enemy.GetComponent<wolfScript>().dead() == true)
        {
            currState = stateOfBattle.WIN;
        }

    }
    //set up the UI
    public void setUPUI()
    {
        if (currState == stateOfBattle.START)
        {

            attackBtn.gameObject.SetActive(false);
            specialBtn.gameObject.SetActive(false);
            defendBtn.gameObject.SetActive(false);
            fleeBtn.gameObject.SetActive(false);

            status.gameObject.SetActive(true);
            write("You've been attacked by a " + enemy.GetComponent<wolfScript>().clss + "!");
            //set the button up for next
            fleeBtn.GetComponentInChildren<Text>().text = "next";

        }
        if (currState == stateOfBattle.PLAYERCH)
        {
            attackBtn.gameObject.SetActive(true);
            specialBtn.gameObject.SetActive(true);
            defendBtn.gameObject.SetActive(true);
            fleeBtn.gameObject.SetActive(true);
            status.gameObject.SetActive(false);
            //set up the butons, text and event listeners
            attackBtn.onClick.AddListener(() => player.GetComponent<characterClass>().attack());

            //dont have functions for defense or special moves yet
        }
        if (currState == stateOfBattle.ENEMCH)
        {
            attackBtn.gameObject.SetActive(false);
            specialBtn.gameObject.SetActive(false);
            defendBtn.gameObject.SetActive(false);
            fleeBtn.gameObject.SetActive(true);
            status.gameObject.SetActive(true);

            write("The " + enemy.GetComponent<wolfScript>().clss + " attacks you.");
            fleeBtn.GetComponentInChildren<Text>().text = "next";

        }
        if (currState == stateOfBattle.WIN)
        {
            attackBtn.gameObject.SetActive(false);
            specialBtn.gameObject.SetActive(false);
            defendBtn.gameObject.SetActive(false);
            fleeBtn.gameObject.SetActive(true);
            status.gameObject.SetActive(true);
            //disable the next button
            playerDecInfo.SetActive(false);
            write("You've won!");
            status.text = st;
            fleeBtn.GetComponentInChildren<Text>().text = "Back to map";
            // fleeBtn.onClick.AddListener(() => this.GetComponent<ChangeScene>().changeScene("Map"));
        }
        if (currState == stateOfBattle.LOSE)
        {
            attackBtn.gameObject.SetActive(false);
            specialBtn.gameObject.SetActive(false);
            defendBtn.gameObject.SetActive(false);
            fleeBtn.gameObject.SetActive(true);
            status.gameObject.SetActive(true);
            //disable the next button
            playerDecInfo.SetActive(false);
            write("You've Lost!");

            fleeBtn.GetComponentInChildren<Text>().text = "Back to map";
            //fleeBtn.onClick.AddListener(() => this.GetComponent<ChangeScene>().changeScene("Map"));
        }
        if (currState == stateOfBattle.STANDBY)
        {
            //once we enter the standby phase, the attack, defend, or special button will have called write to write out what the plaeyer has chosen
            attackBtn.gameObject.SetActive(false);
            specialBtn.gameObject.SetActive(false);
            defendBtn.gameObject.SetActive(false);
            fleeBtn.gameObject.SetActive(false);
            playerDecInfo.gameObject.SetActive(true);
            status.gameObject.SetActive(true);
            writeDMG();
        }

    }

    //have some fucntions that will always show up here
    public void flee()
    {
        //roll 2 d20s, 1 for each combatant
        int playerChance = Random.Range(0, 19);
        int enemyChance = Random.Range(0, 19);
        //add the combatants ms to their dice roll
        int playerTotal = characterClass.MS + playerChance;
        int enemTotal = 3 + enemyChance;
        //checkt to see if we are making a gturn, then 
        if (currState == stateOfBattle.PLAYERCH)
        {
            //if the player rolls higher than the enemy, then they can flee
            if (playerTotal > enemTotal)
            {
                this.GetComponent<ChangeScene>().changeScene("Map");
            }
            else
            {

                write("You tried to flee, but it was of no use!");
            }
        }
        //other-wise they can just leave
        else
        {
            this.GetComponent<ChangeScene>().changeScene("Map");
        }

    }
    //display the combatants info
    public void displayCombatantInfo()
    {
        //wolfs health publicly displayed above its head
        wolfInfo.GetComponentInChildren<Text>().text = enemy.GetComponent<wolfScript>().displayHealth(); ;

        //player info displayed above the head
        playerName.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayName();
        playerClass.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayClass();
        playerHealth.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayHealth();
    }
    //just a function to write out general statments to the info canvas
    public void write(string sample)
    {
        status.GetComponentInChildren<Text>().text = sample;
    }

    //have a function to write out the players damage values as the attack, this is needed bcos there will be a different damage value each time the player attacks, so a set phrase won't work
    public void writeDMG()
    {
        status.GetComponentInChildren<Text>().text = "You deal " + playerLethality + " damage.";
    }
    //decide order of events
    public void next()
    {
        //start of battle becomes player turn
        if (currState == stateOfBattle.START)
        {
            //whenever its the start of the players turn set the player defense mod to 0 
            playerDefenseMod = 0;
            currState = stateOfBattle.PLAYERCH;

        }
        //enemy turn, then turns into player turn
        else if (currState == stateOfBattle.ENEMCH)
        {

            //whenever its the start of the players turn set the player defense mod to 0 
            playerDefenseMod = 0;
            currState = stateOfBattle.PLAYERCH;

        }
        //player turn turns into enemy turn
        else if (currState == stateOfBattle.PLAYERCH)
        {
            //the player has made their choice and the canvas displaying the information that their choice has made comes up   
            writeDMG();
            currState = stateOfBattle.STANDBY;

        }
        else if (currState == stateOfBattle.STANDBY)
        {
            //whenever the wolf has its turn its defense buff is always reset
            enemDefenseMod = 0;
            enemyDecision();
            currState = stateOfBattle.ENEMCH;
        }
        //set up the battle here
        setUPUI();
        //always dsiplay the combatant info no matter where you are
        displayCombatantInfo();
    }

    //this will be what the enemy decides to do, whether it decides to attack or do something else
    public void enemyDecision()
    {
        //the enemy's decisions (the wolf's for now) will be random and weighted
        int enemyDecision = Random.Range(0, 9);

        //60% that the wolf will attack
        if (enemyDecision <= 5)
        {
            //roll to see if the attack hits
            //if (hitScuccess)
            //{  
            // characterClass.currHP -= enemy.GetComponent<wolfScript>().attack();
            //}
            //the resulting dmg is the enemy's PA subtracted by the characters PD, utilizing the wolf scripts attack method
            int dmgResult = enemy.GetComponent<wolfScript>().attack() - characterClass.PD;
            if (dmgResult <= 0)
            {
                dmgResult = 0;
            }
            //the player takes damage, minus teh amount that they were able to defend for
            player.GetComponent<characterClass>().takeDamage(dmgResult - playerDefenseMod);

        }
        //have another option for the wolf
        else
        {
            //defense this time
            //maybe access this from a diff script, preferably the wolf scrpt
            //whenever its the turn of the enemy again, the buff from defense goes away
            enemDefenseMod += 2;
        }
        //update the info of the combatants
        displayCombatantInfo();


    }


    //have a fucntion for the player attack
    //(there is an attack function in the characterClass scrpt just use that to return the PA of the player)
    public void playerAttack()
    {
        //the dmg result is the attack of the player - the physical defense of the 
        int dmgResult = player.GetComponent<characterClass>().attack() - 3;
        if (dmgResult <= 0)
        {
            dmgResult = 0;
        }
        //set up the player lethality for display later
        playerLethality = dmgResult - enemDefenseMod;
        //never let the player do no damage at all
        if(playerLethality <=0 )
        {
            playerLethality = 1;
        }
        //the enemy takes damage, minus the amount that the enemy was able to defend for
        enemy.GetComponent<wolfScript>().currentHealth -= (playerLethality);

    }

    public void playerDefend()
    {
        playerDefenseMod += 2;
    }

    //this will determine if the attacking party hits or not
    /*public bool hitSuccess()
    {
        
        if (true)
        { 
           return true;
        }
        else
        {
            return false;
        }
    }*/
}
    

