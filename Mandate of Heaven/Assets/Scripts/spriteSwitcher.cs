using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwitcher : MonoBehaviour
{


    //have variables for the sprites and the sprite renderers
    public SpriteRenderer rend;
    public Sprite KnightSprite;
    public Sprite MonkSprite;
    public Sprite BeastSprite;
    public Sprite NobleSprite;
    public Sprite AssassinSprite;
    public Sprite WitchSprite;
    public Sprite DoctorSprite;

    // Start is called before the first frame update
    void Start()
    {
        rend = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        KnightSprite = Resources.Load<Sprite>("Art/characterArt/Knight");
        NobleSprite = Resources.Load<Sprite>("Noble");
        AssassinSprite = Resources.Load<Sprite>("Assassin");
        BeastSprite = Resources.Load<Sprite>("Beast");
        DoctorSprite = Resources.Load<Sprite>("Doctor");
        WitchSprite = Resources.Load<Sprite>("Witch");
        MonkSprite = Resources.Load<Sprite>("Monk");
        SetSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetSprite()
    {
        if (characterClass.clss == "Beast")
        {
            rend.sprite = BeastSprite;
        }
        else if (characterClass.clss == "Noble")
        {
            rend.sprite = NobleSprite;
        }
        else if (characterClass.clss == "Knight")
        {
            rend.sprite = KnightSprite;
        }
        else if (characterClass.clss == "Witch")
        {
            rend.sprite = WitchSprite;
        }
        else if (characterClass.clss == "Assassin")
        {
            rend.sprite = AssassinSprite;
        }
        else if (characterClass.clss == "Monk")
        {
            rend.sprite = MonkSprite;
        }
        else if (characterClass.clss == "Doctor")
        {
            rend.sprite = DoctorSprite;
        }
        else
        {
            rend.sprite = KnightSprite;
        }
    }
}
