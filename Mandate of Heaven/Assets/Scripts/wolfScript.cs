using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfScript : MonoBehaviour
{
    battlerHandler mng;
    // Start is called before the first frame update
    public int currentHealth;
    public int totalHealth = 5;
    public int MD = 0;
    public int PD = 3;
    public int MA = 0;
    public int PA = 4;
    public int MS = 3;
    public int AS = 3;

    //have a reference to its target
    public GameObject target;

    void Start()
    {
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


    public void takeDamage(int dmg)
    {
        currentHealth -= dmg + PD;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void attack()
    {
        //call the player's take damage function and pass in the wolof's attack val
        mng.GetComponent<characterClass>().takeDamage(PA);
        
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
}
