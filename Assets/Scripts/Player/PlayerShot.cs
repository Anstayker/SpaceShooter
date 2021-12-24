using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour {
    
    [SerializeField] private float _durationShot = 5.0f;
    [SerializeField] ParticleSystem[] particleSystems;
    private AudioSource _audioSource;
  
    void Start() {                   
            _audioSource = GetComponent<AudioSource>();        
    }

    public void ProcessShoot(bool isShooting) {
        foreach (ParticleSystem gun in particleSystems) {
            if (isShooting) {
                gun.Play();
                _audioSource.loop = true;
                _audioSource.Play();
            }
                
            else {
                gun.Stop();
                _audioSource.loop = false;
            }
        }
    }
  
    private void OnTriggerEnter(Collider other) {
            
        if(other.gameObject.GetComponent<PowerUp>()) {
            StartCoroutine(shotDuration());
            particleSystems[2].gameObject.SetActive(true);
            particleSystems[3].gameObject.SetActive(true);                        
            Destroy(other.gameObject);
        }
    }
   
    private IEnumerator shotDuration() {
        particleSystems[2].gameObject.SetActive(true);
        particleSystems[3].gameObject.SetActive(true);
        yield return new WaitForSeconds(_durationShot);
        particleSystems[2].gameObject.SetActive(false);
        particleSystems[3].gameObject.SetActive(false);
    } 
    
}
