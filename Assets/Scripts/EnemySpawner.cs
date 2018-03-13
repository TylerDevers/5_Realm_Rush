using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] [Range(0.1f, 120f)] float secondsBetweenSpawn = 3f;
	[SerializeField] private GameObject enemySpawn;

	// Use this for initialization
	void Start () {
		StartCoroutine(EnemySpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator EnemySpawn() 
	{
		while(true)
		{
			GameObject enemy = Instantiate(enemySpawn, transform.position, Quaternion.identity);
			enemy.transform.parent = gameObject.transform;
			//print("enemy number " + enemyCount);
			yield return new WaitForSeconds(secondsBetweenSpawn);
		}
	
	}
}
