using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectionNode : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    // The character data this selection node represents
    public Character character;
    // The desired position on the canvas for the stats display object when this selection node is focused
    public Vector2 displayPosition;
    // A reference to the menu navigation component
    public MainMenuNavigation mainMenuNavigation;
    // The image components on this selection node
    [SerializeField]
    private Image[] images;

    private float lerpCounter;
    private bool isHighlighted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        lerpCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpCounter < 1.0f)
            lerpCounter = Mathf.Min(1.0f, lerpCounter + Time.deltaTime);

        if (isHighlighted)
        {
            images[0].color = Color.Lerp(Color.clear, Color.white, lerpCounter);
            images[1].color = Color.Lerp(Color.black, Color.white, lerpCounter);
        }
        else
        {
            images[0].color = Color.Lerp(Color.white, Color.clear, lerpCounter);
            images[1].color = Color.Lerp(Color.white, Color.black, lerpCounter);
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        isHighlighted = true;
        lerpCounter = 0.0f;
        mainMenuNavigation.SetFocusedCharacter(gameObject);
    }

    public void OnSelect(BaseEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData data)
    {
        isHighlighted = false;
        lerpCounter = 0.0f;
        mainMenuNavigation.UnsetFocusedCharacter(gameObject);
    }
}
