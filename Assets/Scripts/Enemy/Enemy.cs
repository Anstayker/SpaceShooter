using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private GameObject _explosion;
    [SerializeField] private float enemyHealth = 1.0f;
    public GameObject explosionPrefab;
  
    private void OnParticleCollision(GameObject other) {
      enemyHealth--;
      contador = contador + 1 ;
      puntuacion.text= "Score: " +contador;
      if(enemyHealth <= 0) {
          _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
          Destroy(_explosion, 2);       
          Destroy(gameObject);         
       }
    }
}
