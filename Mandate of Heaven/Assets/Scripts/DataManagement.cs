using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagement : MonoBehaviour
{
    public static DataManagement instance;

    // The game's current turn
    public int turn;

    // The character data for the player and all AI rivals
    public Character player;
    public Character[] rivals; 

    // The occupants of the player's current location
    public List<Character> occupants;

    void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;

            instance.turn = 0;
            instance.player = new Character();
            instance.rivals = new Character[4];

            for (int i = 0; i < instance.rivals.Length; i++)
                instance.rivals[i] = new Character();
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
