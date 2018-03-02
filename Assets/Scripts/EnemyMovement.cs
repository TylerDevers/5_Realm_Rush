﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField] List<Waypoint> path;

	// Use this for initialization
	void Start () {
        StartCoroutine(PrintAllWaypoints());
		
	}
	
	// Update is called once per frame
	void Update ()
    {
    }

    IEnumerator PrintAllWaypoints()
    {
        print("Starting Patrol...");
        foreach (Waypoint waypoint in path)
        {
            print("Visiting Block: " + waypoint.name);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1);
        }
        print("Ending Patrol.");
    }
}
