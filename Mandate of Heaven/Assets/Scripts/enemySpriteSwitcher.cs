using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpriteSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer rend;
    public Sprite tundraWolf;
    public Sprite crazedKiller;
    public Sprite mageOutcast;
    public Sprite desertBandit;
    void Start()
    {
        rend = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        tundraWolf = Resources.Load<Sprite>("Art/enemyArt/wolf_placeholder");
        crazedKiller = Resources.Load<Sprite>("Art/enemyArt/crazedKiller_placeholder");
        mageOutcast = Resources.Load<Sprite>("Art/enemyArt/mageOutcast_placeholder");
        desertBandit = Resources.Load<Sprite>("Art/enemyArt/desertBandit_placeholder");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
