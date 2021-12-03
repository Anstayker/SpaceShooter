using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    private GameObject _explosion;
    public GameObject explosionPrefab;
    private void OnParticleCollision(GameObject other) {
       _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
       Destroy(_explosion, 2);       
       Destroy(gameObject);
       
    }
    
}
