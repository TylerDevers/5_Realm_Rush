using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectPan;
	[SerializeField] Transform targetEnemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		objectPan.LookAt(targetEnemy);

	}

}
