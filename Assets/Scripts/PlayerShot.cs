using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    
    [SerializeField] ParticleSystem[] particleSystems;
    private AudioSource _audioSource;
    void Start() {
        foreach (ParticleSystem gun in particleSystems)
        {            
            _audioSource = gun.GetComponent<AudioSource>();
        }
        
    }

    public void ProcessShoot(bool isShooting) {
        foreach (ParticleSystem gun in particleSystems) {
            if (isShooting) {
                gun.Play();
                _audioSource.loop = true;
                _audioSource.Play();
            }
                
            else{
                gun.Stop();
                _audioSource.loop = false;
            }
        }
    }

}
