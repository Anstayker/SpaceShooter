using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    public float respawnDelay = 3.0f;
    [SerializeField] private GameObject playerMesh;

    private Collider _playerCollider;
    private const String EnemyTag = "Enemy";

    private GameManager _gameManager;
    
    private void Start() {
        _gameManager = FindObjectOfType<GameManager>();
        _playerCollider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<Enemy>()) {
           DestroyEnemyOnContact(other);
           _gameManager.ChangeState(_gameManager.gameOverState);
       }
    }

   private void OnParticleCollision(GameObject other) {
       if (other.gameObject.CompareTag(EnemyTag)) {
           _gameManager.ChangeState(_gameManager.gameOverState);
       }
   }

   private void DestroyEnemyOnContact(Collision enemy) {
       enemy.gameObject.SetActive(false);
   }
   
}
