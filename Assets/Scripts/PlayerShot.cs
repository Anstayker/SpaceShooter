using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    
    [SerializeField] ParticleSystem[] _particleSystems;

    public void ProcessShoot(bool isShooting) {
        foreach (ParticleSystem gun in _particleSystems) {
            if (isShooting)
                gun.Play();
            else
                gun.Stop();
        }
    }

}
