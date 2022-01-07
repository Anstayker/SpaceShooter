using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    public float respawnDelay = 3.0f;
    public GameObject explosionPrefab;
    
    private GameObject _explosion;
    private const String EnemyTag = "Enemy";
    public static int cantVidas;
    public Image vida1;
    public Image vida2;
    public Image vida3;

    [HideInInspector] public bool isPlayerAlive = true;

    private void Start() {
        cantVidas = 3;
    }
    private void Update() {
        if (cantVidas >= 3) {
            cantVidas = 3;
            vida1.color = Color.white;
            vida2.color = Color.white;
            vida3.color = Color.white;
        }
        if (cantVidas == 2) {
            vida1.gameObject.SetActive(false);
            vida2.color = Color.white;
            vida3.color = Color.white;
        }
        if (cantVidas == 1) {
            vida1.gameObject.SetActive(false);
            vida2.gameObject.SetActive(false);
            vida3.color = Color.white;
        }
        if (cantVidas == 0) {
            vida1.gameObject.SetActive(false);
            vida2.gameObject.SetActive(false);
            vida3.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other) {
        cantVidas = cantVidas - 1;
        
            if(other.gameObject.GetComponent<Enemy>()) { 
                _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                Destroy(_explosion, 2);
                DestroyEnemyOnContact(other);
                if (cantVidas == 0) {
                    isPlayerAlive = false;
                }   
            }             
    }

   private void OnParticleCollision(GameObject other) {
       cantVidas = cantVidas - 1;
       if (cantVidas == 0) {
           if (other.gameObject.CompareTag(EnemyTag)) {
                _explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
                isPlayerAlive = false;
                Destroy(_explosion, 2);
            }
       }
   }

   private void DestroyEnemyOnContact(Collision enemy) {
       Instantiate(explosionPrefab, enemy.transform.position, enemy.transform.rotation);
       enemy.gameObject.SetActive(false);
   }
   
}
