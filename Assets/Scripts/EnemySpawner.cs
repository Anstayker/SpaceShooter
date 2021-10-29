using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnDelayTime = 5.0f;
    [SerializeField] private int maxEnemies = 5;
    
    
    private void Start() {
        StartCoroutine(SpawnEnemy(spawnDelayTime));
    }

    private IEnumerator SpawnEnemy(float waitTime) {
        int enemyCount = 0;
        while (enemyCount <= maxEnemies) {
            yield return new WaitForSeconds(waitTime);
            Instantiate(enemy, transform.position, transform.rotation);
            enemyCount++;
        }

    }

}
