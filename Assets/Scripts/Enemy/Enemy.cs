using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    private GameObject _explosion;
    [SerializeField] private float enemyHealth = 1.0f;
    public GameObject explosionPrefab;
    public PlayerMovement player;

    private void Start() {
        player = FindObjectOfType<PlayerMovement>();
    }
  
    private void OnParticleCollision(GameObject other) {
      enemyHealth--;
	player.contador=player.contador+1;
	player.score.text = "Score: " + player.contador;
      if(enemyHealth <= 0) {
          _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
          Destroy(_explosion, 2);       
          Destroy(gameObject);         
       }
    }
}
