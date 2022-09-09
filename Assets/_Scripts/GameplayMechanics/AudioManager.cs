using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _AudioSource;
    public AudioClip backgroundMusic;

    public AudioClip interactSFX;

    private void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayInteractSFX()
    {
        _AudioSource.PlayOneShot(interactSFX);
    }
}
