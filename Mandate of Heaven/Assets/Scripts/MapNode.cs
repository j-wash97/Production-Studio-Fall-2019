using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    // The name of the node's location
    public string name;

    // A unique numerical ID for the node's location
    public int nodeID;

    // A collection of nodes adjacent to this one
    public List<MapNode> adjacents;

    // The node position on the map
    public Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
