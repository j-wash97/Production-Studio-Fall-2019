using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MapNode : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IPointerExitHandler
{
    // The name of the node's location
    public string locationName;

    // A unique numerical ID for the node's location
    public int nodeID;

    // A collection of nodes adjacent to this one
    public List<MapNode> adjacents;

    // The node position on the map
    public Vector3 position;

    // A collection of the occupants of the node's location
    public List<characterClass> occupants;

    // The node's button on the map
    private Button button;

    // Tracks if the node is being highlighted by the UI
    private bool isHighlighted = false;

    private float lerpCounter;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        lerpCounter = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpCounter < 1.0f)
            lerpCounter = Mathf.Min(1.0f, lerpCounter + Time.deltaTime);

        if (isHighlighted)
        {
            GetComponentInChildren<Text>().color = Color.Lerp(Color.black, Color.white, lerpCounter);
        }
        else
        {
            GetComponentInChildren<Text>().color = Color.Lerp(Color.white, Color.black, lerpCounter);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(button.interactable)
        {
            isHighlighted = true;
            lerpCounter = 0.0f;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(button.interactable)
        {

        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(button.interactable)
        {
            isHighlighted = false;
            lerpCounter = 0.0f;
        }
    }
}
