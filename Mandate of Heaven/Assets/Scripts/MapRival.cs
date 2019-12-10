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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
