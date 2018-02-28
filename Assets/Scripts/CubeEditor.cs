using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour {

	[SerializeField] [Range(10f, 20f)] int gridSize = 10;

	TextMesh textMesh;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 snapPos;
		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
		transform.position = new Vector3(snapPos.x, 0, snapPos.z);

		textMesh = GetComponentInChildren<TextMesh>();
		textMesh.text = snapPos.x/gridSize + "," + snapPos.z/gridSize ;	
	}
}
