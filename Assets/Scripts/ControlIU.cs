using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlIU : MonoBehaviour {
	
	public void Exit() {
		Debug.Log("Cerrar aplicacion");
		Application.Quit();
    }
}
