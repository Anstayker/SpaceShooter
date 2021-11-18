using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    
    [SerializeField] ParticleSystem[] particleSystems;

    public void ProcessShoot(bool isShooting) {
        foreach (ParticleSystem gun in particleSystems) {
            if (isShooting)
                gun.Play();
            else
                //Debug.Log("Me detengo");
                gun.Stop();
        }
    }

}
