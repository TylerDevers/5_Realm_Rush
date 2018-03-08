using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	//expose the enemy collider, since this script is not attached that components object
	[SerializeField] Collider collisionMesh;
	[SerializeField] int hitPoints = 10;

	private void OnParticleCollision(GameObject other)
	{
		ProcessHit();
		if (hitPoints < 1)
		{
			KillEnemy();
		}		
	}

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        hitPoints--;
		//print("current hit points left: " + hitPoints);

    }
}
