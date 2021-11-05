using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
     [SerializeField] private float respawnDelay = 3.0f;
     [SerializeField] private GameObject enemyMesh; 
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<PlayerMovement>())
       {
            StartCoroutine(GameOver(other));
       }
    }
    private IEnumerator GameOver(Collision player)
    {
        player.gameObject.SetActive(false);
        enemyMesh.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}
