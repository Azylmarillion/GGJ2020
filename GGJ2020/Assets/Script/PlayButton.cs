using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource _audioSource;

    public void OnClick()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        StartCoroutine(TurnOnComputer());
    }

    private IEnumerator TurnOnComputer()
    {
        while (_audioSource.isPlaying)
            yield return null;
        SceneManager.LoadScene(1);
    }
}
