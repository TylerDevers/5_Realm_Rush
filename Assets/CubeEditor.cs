using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]

public class CubeEditor : MonoBehaviour {

    TextMesh textMesh;

	[SerializeField] [Range(1f, 20f)] int gridSize = 10;
    
    void Start()
    {

    }
    void Update()
    {
        string labelText;
        Vector3 snapPos;

		snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
		snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

		transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
        textMesh = GetComponentInChildren<TextMesh>();
        labelText = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;

    }

}
