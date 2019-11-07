using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class battlerHandler : MonoBehaviour
{
    public Canvas display;
    public Text wolfInfo;
    public Text playerHealth;
    public Text playerName;
    public Text playerClass;
    public Text status;
    public Button attackBtn;
    public Button defendBtn;
    public Button specialBtn;
    public Button fleeBtn;

    public GameObject player;
    public GameObject enemy;

    public bool playerTurn;
    public bool enemTurn;
    public bool endCombat;
    public bool playerV;
    public string st;

    Random newrand = new Random();
    // Start is called before the first frame update
    void Start()
    {
        displayCombatantInfo();
        playerTurn = true;
        enemTurn = false;
        endCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        }
    }

    public bool isDead()
    {
        if (player.GetComponent<characterClass>().dead())
        {

            endCombat = true;
            playerV = false;
            return endCombat;
        }
        if(enemy.GetComponent<wolfScript>().dead())
        {
            endCombat = true;
            playerV = true;
            return endCombat;
        }
        else
        {
            endCombat = false;
            return endCombat;
        }
    }
    public void setUPUI()
    {
        //add a bunch of event listeners
        attackBtn.onClick.AddListener(() => player.GetComponent<characterClass>().attack());
        //fleeBtn.onClick.AddListener(() => flee());
    }

    //have some fucntions that will always show up here
    public void flee()
    {
        int chance = Random.Range(0, 10);
        if (chance == 9)
        {
            this.GetComponent<ChangeScene>().changeScene("Map");
        }
        else
        {

        }

    }

    public void displayCombatantInfo()
    {
        wolfInfo.GetComponentInChildren<Text>().text = enemy.GetComponent<wolfScript>().displayHealth(); ;
        
        playerName.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayName();
        playerClass.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayClass();
        playerHealth.GetComponentInChildren<Text>().text = player.GetComponent<characterClass>().displayHealth();
    }

    public void write()
    {
        status.GetComponentInChildren<Text>().text = st;
    }
}
