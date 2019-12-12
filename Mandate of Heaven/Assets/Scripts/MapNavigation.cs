using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MapNavigation : MonoBehaviour
{
    // Collections for each location object and map node component
    public GameObject[] mapNodes;
    private MapNode[] locNodes;

    // References to player object and character data
    public GameObject player;
    private Character playerCharacter;

    // References to rivals object, icon objects, and character data
    public GameObject rivals;
    private Transform[] rivalIcons;
    private Character[] rivalCharacters;

    // Values to store characters' destination positions
    private Vector3 playerDestination;
    private Vector3[] rivalDestinations;

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
        playerCharacter = player.GetComponent<MapPlayer>().character;

        // Ensure the player character is stored in the location's occupants collection
        if (!locNodes[playerCharacter.location].occupants.Contains(playerCharacter))
            locNodes[playerCharacter.location].occupants.Add(playerCharacter);

        // Store the rivals' character data
        rivalCharacters = rivals.GetComponent<MapRival>().rivals;

        // Ensure the rival characters are stored in their respective location's occupants collection
        for(int i = 0; i < rivalCharacters.Length; i++)
        {
            Character rival = rivalCharacters[i];

            if (!locNodes[rival.location].occupants.Contains(rival))
                locNodes[rival.location].occupants.Add(rival);
        }

        // Store the rivals' icon objects
        rivalIcons = rivals.GetComponentsInChildren<Transform>().Where(x => x.gameObject != rivals).ToArray();

        // Initiate rival destination positions
        rivalDestinations = new Vector3[rivalCharacters.Length];

        // Set the player's location on the map to its current location
        SetPlayerUIPositon();
        player.transform.position = playerDestination;

        // Set each rivals' location on the map to its current location
        for(int i = 0; i < rivalIcons.Length; i++)
        {
            SetRivalUIPosition(i);
            rivalIcons[i].position = rivalDestinations[i];
        }

        // Show the valid moves the character can make on the map
        DisplayValidMove();

        // Set the Data Manager to save the list of occupants where the player is located when the scene changes
        SceneManager.activeSceneChanged += SaveOccupants;
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpCounter < 1.0f)
        {
            // Progress the transition counter
            lerpCounter = Mathf.Min(1.0f, lerpCounter + (Time.deltaTime / 3.0f));

            // Transition the player icon to its new destination
            player.transform.position = Vector3.Lerp(player.transform.position,
                                                     playerDestination,
                                                     lerpCounter);

            // Transition each rival icon to its new destination
            for (int i = 0; i < rivalIcons.Length; i++)
            {
                rivalIcons[i].position = Vector3.Lerp(rivalIcons[i].position,
                                                      rivalDestinations[i],
                                                      lerpCounter);
            }

            if (lerpCounter == 1.0f)
            {
                EventSystem.current.SetSelectedGameObject(null);
                SceneManager.LoadScene(2);
            }
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

    /// <summary>
    /// Makes the player character's target destination the specified integer
    /// </summary>
    /// <param name="nodeID">The location ID of the specified target</param>
    public void SetPlayerCharacterLocation(int nodeID)
    {
        // Reset the location if a new target is given
        if (nodeID != playerCharacter.location)
        {
            // Remove the character from its current location
            locNodes[playerCharacter.location].occupants.Remove(playerCharacter);

            // Add the character to its new location
            locNodes[nodeID].occupants.Add(playerCharacter);
            playerCharacter.location = nodeID;
        }

        BeginIconTransition();
    }

    private void SetRivalCharacterLocation(Character rival, int nodeID)
    {
        // Do nothing if the character is moving to the same location
        if (nodeID == rival.location)
            return;

        // Remove the character from its current location
        locNodes[rival.location].occupants.Remove(rival);

        // Add the character to its new location
        locNodes[nodeID].occupants.Add(rival);
        rival.location = nodeID;
    }

    /// <summary>
    /// Initiates the movement of character icons on the map
    /// </summary>
    private void BeginIconTransition()
    {
        // Set each rival character's target destination
        for(int i = 0; i < rivalCharacters.Length; i++)
        {
            // Have the rival determine a target destination

            // Set its new target destination
            //SetRivalCharacterLocation(rivalCharacters[i], Random.Range(0, locNodes.Length));
        }

        // Set the player's position in the scene
        SetPlayerUIPositon();

        // Set each rivals' position in the scene
        for(int i = 0; i < rivalCharacters.Length; i++)
        {
            SetRivalUIPosition(i);
        }

        // Set the transition's lerp counter to zero
        lerpCounter = 0.0f;

        // Update the map UI
        DisplayValidMove();
    }

    /// <summary>
    /// Set the player character's position in the scene based on the occupancy of their target destination
    /// </summary>
    private void SetPlayerUIPositon()
    {
        // Find the player's destination map node
        MapNode destination = locNodes[playerCharacter.location];
        // Determine the player's index in the occupants list
        int index = destination.occupants.FindIndex(x => x == playerCharacter);
        // Determine the destination's position in the scene
        Vector3 pos = destination.position;

        // Determine a position that orbits the destination position based on the rival's occupant index
        float orbitAngle = 2.0f * Mathf.PI * ((float)index / (float)(rivalCharacters.Length + 1));

        pos.x += Mathf.Cos(orbitAngle);
        pos.y += Mathf.Sin(orbitAngle);

        playerDestination = pos;
    }

    /// <summary>
    /// Sets the specified rival's position in the scene based on the occupancy of their target destination
    /// </summary>
    /// <param name="rivalIndex">The index of the desired rival in rivalIcons and rivalCharacters</param>
    /// <returns></returns>
    private void SetRivalUIPosition(int rivalIndex)
    {
        Character rival = rivalCharacters[rivalIndex];
        // Find the rival's destination map node
        MapNode destination = locNodes[rival.location];
        // Determine the rival's index in the occupants list
        int index = destination.occupants.FindIndex(x => x == rival);
        // Determine the destination's position in the scene
        Vector3 pos = destination.position;

        // Determine a position that orbits the destination position based on the rival's occupant index
        float orbitAngle = 2.0f * Mathf.PI * ((float)index / (float)(rivalCharacters.Length + 1));

        pos.x += Mathf.Cos(orbitAngle);
        pos.y += Mathf.Sin(orbitAngle);

        // Set the orbiting position as the rival's destination
        rivalDestinations[rivalIndex] = pos;
    }

    /// <summary>
    /// Save the List of occupant for where the player character is located to the Data Manager
    /// </summary>
    /// <param name="current"></param>
    /// <param name="next"></param>
    private void SaveOccupants(Scene current, Scene next)
    {
        DataManagement.instance.occupants = locNodes[playerCharacter.location].occupants;
    }
}
