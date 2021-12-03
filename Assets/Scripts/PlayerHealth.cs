using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    
    [SerializeField] private float respawnDelay = 3.0f;
    [SerializeField] private GameObject playerMesh;
    private GameObject _explosion;
    public GameObject explosionPrefab;

    private Collider _playerCollider;
    private const String EnemyTag = "Enemy";
    
    private void Start() {
        _playerCollider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision other) {
        _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
       if(other.gameObject.GetComponent<Enemy>()) {
           Destroy(_explosion, 2);
           DestroyEnemyOnContact(other);
            StartCoroutine(GameOver());
       }
    }

   private void OnParticleCollision(GameObject other) {
       _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
       if (other.gameObject.CompareTag(EnemyTag)) {
           Destroy(_explosion, 2);
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
