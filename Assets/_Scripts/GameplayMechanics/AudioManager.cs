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
        Destructor.AddProgress += PlayInteractSFX;
    }

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = gameObject.AddComponent<AudioSource>();
        _AudioSource.clip = backgroundMusic;
        _AudioSource.Play();
        _AudioSource.volume = PlayerPrefs.GetFloat("Volume", 1.0f);

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
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
            _AudioSource.volume = 1.0f;
        }

        else
        {
            PlayerPrefs.SetFloat("Volume", 0.0f);
            _AudioSource.volume = 0.0f;
        }
            
    }

    private void OnDisable()
    {
        MainMenu.ToggleSound -= SetSoundStatus;
        Destructor.AddProgress -= PlayInteractSFX;
    }
}
