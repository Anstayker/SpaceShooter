using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    [SerializeField] private float respawnDelay = 3.0f;
    [SerializeField] private GameObject playerMesh;

    private Collider _playerCollider;
    private const String EnemyTag = "Enemy";
    
    private void Start() {
        _playerCollider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<Enemy>()) {
           DestroyEnemyOnContact(other);
            StartCoroutine(GameOver());
       }
    }

   private void OnParticleCollision(GameObject other) {
       if (other.gameObject.CompareTag(EnemyTag)) {
           StartCoroutine(GameOver());
       }
   }

   private void DestroyEnemyOnContact(Collision enemy) {
       enemy.gameObject.SetActive(false);
   }

   private IEnumerator GameOver() {
        playerMesh.SetActive(false);
        _playerCollider.enabled = false;
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}
