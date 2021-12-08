using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    
	private bool _active;

	void Awake() {
		gameObject.SetActive(false);
    }
	
   public void InPause (bool value) {
	   if(value) {
		   _active = !_active;
		   gameObject.SetActive(_active);
		   Time.timeScale = (_active) ? 0 : 1f;
	   }
   } 
   
}
