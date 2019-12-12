using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRival : MonoBehaviour
{
    public Character[] rivals;
    [SerializeField]
    private SpriteRenderer[] icons;

    void Start()
    {
        rivals = DataManagement.instance.rivals;
        icons = gameObject.GetComponentsInChildren<SpriteRenderer>();

        // Set each rival's icon sprite to appear on screen
        for(int i = 0; i < rivals.Length; i++)
        { icons[i].sprite = rivals[i].mapIcon; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
