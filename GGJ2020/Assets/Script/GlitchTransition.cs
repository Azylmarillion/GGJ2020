using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchTransition : MonoBehaviour
{
    [SerializeField] private AudioClip _glitchSound = null;

    internal void Glitch()
    {
        GetComponent<Animator>().SetTrigger("glith"); 
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = _glitchSound;
        audioSource.loop = false;
        audioSource.Play();
    }

    public void ChangeEra()
    {
        FindObjectOfType<GameManager>().ChangeEra();
    }
}
