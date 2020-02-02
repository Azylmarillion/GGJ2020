using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] float deltaPulse = 0;

    private AudioSource _audioSource;
    private Image _playImg;

    private void Start()
    {
        _playImg = GetComponent<Image>();
        StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        float pulse = 1;
        while (true)
        {
            _playImg.color = new Color(1, 1, 1, pulse);
            if (pulse > 1)
                deltaPulse *= -1;
            if (pulse < 0.7)
                deltaPulse *= -1;
            pulse += deltaPulse;
            yield return null;
        }
    }

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
