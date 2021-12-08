using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {
    
    void Awake() {
        MusicManager[] objects = FindObjectsOfType<MusicManager>();
        if (objects.Length > 1) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
