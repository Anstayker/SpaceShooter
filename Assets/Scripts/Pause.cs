using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool active;
    Canvas canvas;
    
    

    void Awake()
    {
        canvas=GetComponent<Canvas>();
	canvas.enabled= false;
    }

   

   public void InPause (bool value)
   {
	if(value)
	{
        active = !active;
	canvas.enabled = active;
	Time.timeScale = (active) ? 0 : 1f;
	}
   } 
   
}
