using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ApplyAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
            _audioSource.Play(); 
    }
}
