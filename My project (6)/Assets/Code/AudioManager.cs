using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip PlayerThrow;
    public AudioClip Death;
    public AudioClip PlayerDeath;
    public AudioClip Shatter;
    public AudioClip TableSFX;



    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }



}
