using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlIU : MonoBehaviour {
	
	public void Exit() {
		Debug.Log("Cerrar aplicacion");
		Application.Quit();
    }

        public void RestartGame() {
		Debug.Log("Reiniciar aplicacion");
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
   }
 
      

}
