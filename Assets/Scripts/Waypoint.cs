﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
	const int gridSize = 10;
	public bool isExplored = false;

	public Waypoint exploredFrom;
	Vector2Int gridPos;
	public bool isPlaceable = true;
	[SerializeField] private Tower towerPrefab;

	//getter methods for CubeEditor
	public int GetGridSize()
	{
		return gridSize;
	}

	public Vector2Int GetGridPos()
	{
		return new Vector2Int(
		Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize)
		);
	}


	public void SetTopColor(Color color)
	{
		MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
		topMeshRenderer.material.color = color;
	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (isPlaceable)
			{
				Instantiate(towerPrefab, transform.position, Quaternion.identity);
				isPlaceable = false;
			} 
			else 
			{
				print("not PLaceable");
			}

		}
	}

}
