using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	// Use this for initialization
	void Start () {
		LoadBlocks();
		ColorStartAndEnd();
		ExploreNeighbors();
	}

    // Update is called once per frame
    void Update () {
		
	}

	void ExploreNeighbors()
	{
		Vector2Int startBlock = startWaypoint.GetGridPos();
		
		foreach (Vector2Int direction in directions)
		{
			Vector2Int explorationCoordinates = startBlock + direction;
			try
			{
				// change color of neighbor
				grid[explorationCoordinates].SetTopColor(Color.blue);

			}
			catch
			{
				print(explorationCoordinates + " Not Found");
			}
		}
	}
    void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.yellow);
		endWaypoint.SetTopColor(Color.red);
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
