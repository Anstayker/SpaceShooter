using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float startDelayTime = 1.0f;
    [SerializeField] private float spawnDelayTime = 3.0f;
    [SerializeField] private int maxEnemies = 4;

    public List<GameObject> waypoints;
    [SerializeField] private bool visualizeWaypoints;
    
    private void Start() {
        StartCoroutine(SpawnEnemy(spawnDelayTime));
    }

    private IEnumerator SpawnEnemy(float waitTime) {
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
