using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[CreateAssetMenu(menuName = "musicCollection")]
public class MusicCollection : ScriptableObject
{
    [SerializeField] protected AudioClip _egyptIntro;
    [SerializeField] protected AudioClip _egyptMain;
    [SerializeField] protected float _egyptVolume = 1.0f;

    [SerializeField] protected AudioClip _renaissanceIntro;
    [SerializeField] protected AudioClip _renaissanceMain;
    [SerializeField] protected float _renaissanceVolume = 1.0f;

    [SerializeField] protected AudioClip _samouraiIntro;
    [SerializeField] protected AudioClip _samouraiMain;
    [SerializeField] protected float _samouraiVolume = 1.0f;

    [SerializeField] protected AudioClip _hackermanIntro;
    [SerializeField] protected AudioClip _hackermanMain;
    [SerializeField] protected float _hackermanVolume = 1.0f;



    public List<AudioClip> intro => new List<AudioClip>() { _egyptIntro, _renaissanceIntro, _samouraiIntro, _hackermanIntro };
    public List<AudioClip> main => new List<AudioClip>() { _egyptMain, _renaissanceMain, _samouraiMain, _hackermanMain };
    public List<float> volume => new List<float>() { _egyptVolume, _renaissanceVolume, _samouraiVolume, _hackermanVolume };
}
