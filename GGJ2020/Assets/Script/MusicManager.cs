﻿using UnityEngine;
using System.Collections;
using System;

public class MusicManager : ChangeOnTimeShift
{
    [SerializeField] private MusicCollection _music = null;

    private AudioSource _audioSource = null;

    public override void OnTimeShift()
    {
        if(_audioSource == null)
            _audioSource = GetComponent<AudioSource>();

        _audioSource.Pause();

        if(_music.intro[TimeShifter.CurrentEra] != null)
            PlayIntro();            
        else
            PlayMain();
    }

    private void PlayMain()
    {
        _audioSource.clip = _music.main[TimeShifter.CurrentEra];
        _audioSource.volume = _music.volume[TimeShifter.CurrentEra];
        _audioSource.loop = true;
        _audioSource.Play();
    }

    private void PlayIntro()
    {
        _audioSource.clip = _music.intro[TimeShifter.CurrentEra];
        _audioSource.volume = _music.volume[TimeShifter.CurrentEra];
        _audioSource.loop = false;
        _audioSource.Play();
        StartCoroutine(WaitForEndOfIntro());
    }

    private IEnumerator WaitForEndOfIntro()
    {
        while (_audioSource.isPlaying)
            yield return null;
        PlayMain();
    }
}
