using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHealth : MonoBehaviour
{
    public void increase()
    {
        ChangeScene.HP++;
    }

    public void decrease()
    {
        ChangeScene.HP--;
    }

}
