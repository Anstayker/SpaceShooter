using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    
    public float respawnDelay = 3.0f;
    public GameObject explosionPrefab;
    
    private GameObject _explosion;
    private const String EnemyTag = "Enemy";

    [HideInInspector] public bool isPlayerAlive = true;
    
    private void OnCollisionEnter(Collision other) {
        _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
       if(other.gameObject.GetComponent<Enemy>()) {
           Destroy(_explosion, 2);
           DestroyEnemyOnContact(other);
           isPlayerAlive = false;
       }
    }

   private void OnParticleCollision(GameObject other) {
       _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
       if (other.gameObject.CompareTag(EnemyTag)) {
           isPlayerAlive = false;
           Destroy(_explosion, 2);
       }
   }

   private void DestroyEnemyOnContact(Collision enemy) {
       Instantiate(explosionPrefab, enemy.transform.position, enemy.transform.rotation);
       enemy.gameObject.SetActive(false);
   }
   
}
