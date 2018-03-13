using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	[SerializeField] float secondsBetweenSpawn = 3f;
	[SerializeField] private GameObject enemy;
	private int enemyCount = 0;

	// Use this for initialization
	void Start () {
		StartCoroutine(EnemySpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator EnemySpawn() 
	{
		while(enemyCount < 5)
		{

			Instantiate(enemy, transform.position, Quaternion.identity);
			enemyCount ++;
			//print("enemy number " + enemyCount);
			yield return new WaitForSeconds(secondsBetweenSpawn);
		}
	
	}
}
