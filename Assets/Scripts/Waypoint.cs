﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	Vector2Int snapPos;

	const int gridSize = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	    public int GetGridSize()
    {
        return gridSize;
    }

	public Vector2 GetGridPosition()
	{
		return new Vector2Int(
			Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        	Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
		);
	}
}