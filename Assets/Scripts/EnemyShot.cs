using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour {

    [SerializeField] private float shootDelay = 2.0f;
    [SerializeField] private float startDelay = 1.0f;
    [SerializeField] private int bulletsPerShot = 1;
    [SerializeField] private float delayBetweenShots = 0.5f;
    
    [SerializeField] private ParticleSystem[] enemyGuns;
    
    private bool _isShooting = false;

    private void Update() {
        StartShooting();
    }

    private void StartShooting() {
        if (_isShooting) return;
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine() {
        if (_isShooting) yield break;
        
        _isShooting = true;
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < bulletsPerShot; i++) {
            foreach (ParticleSystem gun in enemyGuns) {
                gun.Emit(1);
            }
            yield return new WaitForSeconds(delayBetweenShots);
        }

        
        yield return new WaitForSeconds(shootDelay);

        _isShooting = false;
    }

}
