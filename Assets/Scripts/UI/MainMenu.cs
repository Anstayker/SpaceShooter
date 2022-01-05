using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Quit() {
		Debug.Log("Cerrar aplicacion");
		Application.Quit();
    }

    public void PlayGame() {
		Debug.Log("Play");
		SceneManager.LoadScene("Level");
		Time.timeScale = 1f;
   }
   public void Credits() {
		Debug.Log("Credits");
		SceneManager.LoadScene("Credits");
		Time.timeScale = 1f;
   }
}
