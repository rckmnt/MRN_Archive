using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dingding : MonoBehaviour {

    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
            audioSource.Play();
        }
    }

    
}
