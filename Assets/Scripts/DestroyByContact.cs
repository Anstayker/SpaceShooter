using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
     [SerializeField] private float respawnDelay = 3.0f;
     [SerializeField] private GameObject playerMesh; 
   private void OnCollisionEnter(Collision other) {
       if(other.gameObject.GetComponent<Enemy>())
       {
            StartCoroutine(GameOver(other));
       }
    }
    private IEnumerator GameOver(Collision enemy)
    {
        enemy.gameObject.SetActive(false);
        playerMesh.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);        
    }
}
