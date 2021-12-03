using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField] private int life;

    private void OnParticleCollision(GameObject other) {
	life--;

	if(life<0){
        	Destroy(gameObject);
	}
    }
}
