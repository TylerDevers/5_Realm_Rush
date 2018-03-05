using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
	}

    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.blue);
		endWaypoint.SetTopColor(Color.red);
    }

    // Update is called once per frame
    void Update () {
		
	}
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
		foreach(Waypoint waypoint in waypoints)
		{
			bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
			if (isOverlapping)
			{
				Debug.LogWarning("skipping overlapping block " + waypoint);
			} 
			else
			{
				grid.Add(waypoint.GetGridPos(), waypoint); //using Waypoint.cs helper method for Vector2Int
				//waypoint.SetTopColor(Color.red);
			}
		}	
    }


}
