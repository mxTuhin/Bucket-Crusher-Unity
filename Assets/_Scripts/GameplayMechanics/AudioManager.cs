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
        MainMenu.ToggleSound += SetSoundStatus;
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

    public void SetSoundStatus(bool _status)
    {
        if (_status)
            _AudioSource.volume = 1.0f;
        else
            _AudioSource.volume = 0.0f;
    }

    private void OnDisable()
    {
        MainMenu.ToggleSound -= SetSoundStatus;
    }
}
