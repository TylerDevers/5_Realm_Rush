using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField] Transform objectPan;
	[SerializeField] Transform targetEnemy;
	[SerializeField] ParticleSystem projectileParticle;
	[SerializeField] float attackRange = 30f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (targetEnemy)
		{
			objectPan.LookAt(targetEnemy);
			FireAtEnemy();
		}
		else
		{
			Shoot(false);
		}

	}

	void FireAtEnemy()
	{
		float distanceToEnemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
		if (distanceToEnemy <= attackRange)
		{
			Shoot(true);
		}
		else
		{
			Shoot(false);
		}
	}

    private void Shoot(bool isActive)
    {
        var emmissionModule = projectileParticle.emission;
		emmissionModule.enabled = isActive;
    }
}
