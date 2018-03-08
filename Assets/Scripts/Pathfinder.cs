using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
	Queue<Waypoint> queue = new Queue<Waypoint>();
	public List<Waypoint> path = new List<Waypoint>();

	Vector2Int[] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};
    [SerializeField] bool isRunning = true;
	Waypoint searchCenter;


 

	public List<Waypoint> GetPath()
	{
		LoadBlocks();
		ColorStartAndEnd();
		BreadthFirstSearch();
		CreatePath();
		return path;
	}
    private void CreatePath()
    {
		if (path.Count <= 0)
		{
			path.Add(endWaypoint);
			Waypoint previous = endWaypoint.exploredFrom;
			while (previous != startWaypoint)
			{
				path.Add(previous);
				previous = previous.exploredFrom;
			}
			path.Add(startWaypoint);
			path.Reverse();
		} else 
		{
			print("path already exists");
		}
    }


    private void BreadthFirstSearch() //using breadth first algorithm
    {
        queue.Enqueue(startWaypoint);
		while(queue.Count > 0)
		{
			searchCenter = queue.Dequeue();
			searchCenter.isExplored = true;

			HaltIfEndFound();
			ExploreNeighbors();
		}
		//print("finished Pathfinding?");
    }

    private void HaltIfEndFound()
    {
		if (searchCenter == endWaypoint)
		{
			isRunning = false;
		}
    }

	void ExploreNeighbors()
	{
		if (!isRunning) {return;} //prevent infinite loop when called from pathfind()
		
		foreach (Vector2Int direction in directions)
		{
			Vector2Int neighborCoordinates = searchCenter.GetGridPos() + direction;
			if (grid.ContainsKey(neighborCoordinates))
            {
                QueueNewNeighbors(neighborCoordinates);
            }
		}
	}

    private void QueueNewNeighbors(Vector2Int neighborCoordinates)
    {
        // change color of neighbor
        Waypoint neighbor = grid[neighborCoordinates];
		if (neighbor.isExplored || queue.Contains(neighbor))
		{
			//do nothing
		}
		else
		{
			//neighbor.SetTopColor(Color.blue);
			queue.Enqueue(neighbor);
			neighbor.exploredFrom = searchCenter;
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
				//Debug.LogWarning("skipping overlapping block " + waypoint);
			} 
			else
			{
				grid.Add(waypoint.GetGridPos(), waypoint); //using Waypoint.cs helper method for Vector2Int
				//waypoint.SetTopColor(Color.red);
			}
		}	
    }


}
