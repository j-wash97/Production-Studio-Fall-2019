using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MapNavigation : MonoBehaviour
{
    // Collections for each location object and map node component
    public GameObject[] mapNodes;
    private MapNode[] locNodes;

    // References to player object and character data
    public GameObject player;
    private characterClass playerCharacter;

    private float lerpCounter = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Sort location nodes by their identifier
        mapNodes = mapNodes.OrderBy(x => x.GetComponent<MapNode>().nodeID).ToArray();

        // Store node components in their own collection
        locNodes = new MapNode[mapNodes.Length];
        for (int i = 0; i < mapNodes.Length; i++)
            locNodes[i] = mapNodes[i].GetComponent<MapNode>();

        // Store the player's character data
        playerCharacter = player.GetComponent<characterClass>();

        // Set the player's location on the map to its current location
        player.transform.position = locNodes[playerCharacter.location].position;

        // Ensure the player character is stored in the location's occupants collection
        if (!locNodes[playerCharacter.location].occupants.Contains(playerCharacter))
            locNodes[playerCharacter.location].occupants.Add(playerCharacter);

        // Show the valid moves the character can make on the map
        DisplayValidMove();
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpCounter < 1.0f)
        {
            lerpCounter = Mathf.Min(1.0f, lerpCounter + (Time.deltaTime / 3.0f));

            player.transform.position = Vector3.Lerp(player.transform.position,
                                                     locNodes[playerCharacter.location].position,
                                                     lerpCounter);

            if (lerpCounter == 1.0f)
                EventSystem.current.SetSelectedGameObject(null);
        }
    }

    void DisplayValidMove()
    {
        // Access the character's current location and find its adjacent locations
        MapNode[] adjacents = locNodes[playerCharacter.location].adjacents.ToArray();

        // If a location is adjacent, set its interactivity on the map to reflect that
        for(int i = 0; i < locNodes.Length; i++)
        {

            if (adjacents.Contains(locNodes[i]) || i == playerCharacter.location)
            {
                mapNodes[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                mapNodes[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void SetPlayerCharacterLocation(int nodeID)
    {
        // Do nothing if the character is moving to the same location
        if (nodeID == playerCharacter.location)
            return;

        // Remove the character from its current location
        locNodes[playerCharacter.location].occupants.Remove(playerCharacter);

        // Add the character to its new location
        locNodes[nodeID].occupants.Add(playerCharacter);
        playerCharacter.location = nodeID;

        // Set the transition's lerp counter to zero
        lerpCounter = 0.0f;

        // Update the map UI
        DisplayValidMove();
    }
}
