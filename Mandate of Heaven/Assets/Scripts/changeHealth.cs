using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHealth : MonoBehaviour
{
    public void increase()
    {
        characterClass.currentHP++;
    }

    public void decrease()
    {
        characterClass.currentHP--;
    }

}
