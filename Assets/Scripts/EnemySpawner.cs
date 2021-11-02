using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnDelayTime = 5.0f;
    [SerializeField] private int maxEnemies = 5;

    public List<GameObject> waypoints;
    [SerializeField] private bool visualizeWaypoints;
    
    private void Start() {
        StartCoroutine(SpawnEnemy(spawnDelayTime));
    }

    private IEnumerator SpawnEnemy(float waitTime) {
        int enemyCount = 0;
        while (enemyCount < maxEnemies) {
            yield return new WaitForSeconds(waitTime);
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            newEnemy.GetComponent<EnemyMovement>().path = waypoints;
            enemyCount++;
        }

    }

    public void CreateNewWaypoint() {
        GameObject newEmptyObject = new GameObject("Waypoint " + waypoints.Count);
        newEmptyObject.transform.position = this.transform.position;
        newEmptyObject.transform.parent = this.transform;
        waypoints.Add(newEmptyObject);
        //return Instantiate(enemy, transform.position, Quaternion.identity);
    }

    private void OnDrawGizmos() {
        if (visualizeWaypoints && waypoints.Count > 0) {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.transform.position, waypoints[0].transform.position);
            for (int i = 0; i < waypoints.Count - 1; i++) {
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
            }            
        }
    }
}
