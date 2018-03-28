using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem hitDeathParticlePrefab;

	// Use this for initialization
	void Start () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    
    void ProcessHit()
    {
        hitPoints --;
        hitParticlePrefab.Play();
        //print("current hitpoints are " + hitPoints);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(hitDeathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(gameObject);
    }
}