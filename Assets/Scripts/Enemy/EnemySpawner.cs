using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] private GameObject enemy;
    [SerializeField] private float startDelayTime = 1.0f;
    [SerializeField] private float spawnDelayTime = 5.0f;
    [SerializeField] private int maxEnemies = 5;
    [SerializeField] private Transform spawnerTrigger;
    
    public List<GameObject> waypoints;
    [SerializeField] private bool visualizeWaypoints;

    private bool _isSpawning = false;
    private Camera _camera;
    
    private void Start() {
        _camera = FindObjectOfType<Camera>();
    }

    private void Update() {
        if (!_isSpawning && _camera.transform.position.z >= spawnerTrigger.position.z) {
            _isSpawning = true;
            StartCoroutine(SpawnEnemy(spawnDelayTime));
        }
    }

    public IEnumerator SpawnEnemy(float waitTime) {
        if (_isSpawning) {
            int enemyCount = 0;
            yield return new WaitForSeconds(startDelayTime);
            while (enemyCount < maxEnemies) {
                GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation);
                newEnemy.GetComponent<EnemyMovement>().path = waypoints;
                enemyCount++;
                yield return new WaitForSeconds(waitTime);    
            }            
        }
    }

    public void CreateNewWaypoint() {
        foreach (GameObject waypoint in waypoints) {
            if (waypoint == null) {
                waypoints.Remove(waypoint);
            }
        }
        GameObject newEmptyObject = new GameObject("Waypoint " + waypoints.Count);
        newEmptyObject.transform.position = this.transform.position;
        newEmptyObject.transform.parent = this.transform;
        waypoints.Add(newEmptyObject);
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
