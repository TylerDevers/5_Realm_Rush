using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour {

    TextMesh textMesh;
    
    Waypoint waypoint;   

    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    } 

    void Start()
    {

    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        string labelText;
        textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.GetGridSize();
        labelText = waypoint.GetGridPosition().x / gridSize + "," + waypoint.GetGridPosition().y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();

        transform.position = new Vector3(
            waypoint.GetGridPosition().x, 
            0f, 
            waypoint.GetGridPosition().y
        );
    }

}
