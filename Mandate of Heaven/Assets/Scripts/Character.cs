using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An enumerator used to access the indices of a character's attribute array
public enum CharacterAttribute
{
    // The character's current health value
    Health = 0,
    // The character's physical attack value
    PhysAttk = 1,
    // The character's magical attack value
    MagAttk = 2,
    // The character's physical defense value
    PhysDef = 3,
    // The character's magical defense value
    MagDef = 4,
    // The character's attack speed value
    AttkSpd = 5,
    // The character's movement speed value
    MoveSpd = 6,
    // The character's special ability
    Special = 7
}

// An enumerator describing a character's special abilities
public enum SpecialAbility
{
    HealingPotion = 0,
    StyleChange = 1,
    RecklessCounter = 2,
    Analysis = 3
}

[Serializable]
public class Character
{
    // The name of the character
    public string name;
    // An array that contains the 7 numerical attributes defined in CharacterAttribute enumerator
    public int[] attributes = new int[8];
    // The current location of the character
    public int location;
    // The character's full body sprite
    public Sprite fullBody;
    // The character's map icon sprite
    public Sprite mapIcon;

    /// <summary>
    /// Increments a specified attribute by a given value
    /// </summary>
    /// <param name="attribute">The attribute enumerator to be adjusted</param>
    /// <param name="value">The value by which the attribute will be adjusted</param>
    public void AdjustStatValue(CharacterAttribute attribute, int value)
    {
        if (attribute != CharacterAttribute.Special)
            attributes[(int)attribute] += value;
    }

    public void SetSpecial(SpecialAbility ability)
    {
        attributes[(int)CharacterAttribute.Special] = (int)ability;
    }
}
