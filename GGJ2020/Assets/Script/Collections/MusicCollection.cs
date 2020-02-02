using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[CreateAssetMenu(menuName = "musicCollection")]
public class MusicCollection : ScriptableObject
{
    [SerializeField] protected AudioClip _egyptIntro;
    [SerializeField] protected AudioClip _egyptMain;
    [SerializeField] protected AudioClip _renaissanceIntro;
    [SerializeField] protected AudioClip _renaissanceMain;
    [SerializeField] protected AudioClip _samouraiIntro;
    [SerializeField] protected AudioClip _samouraiMain;
    [SerializeField] protected AudioClip _hackermanIntro;
    [SerializeField] protected AudioClip _hackermanMain;


    public List<AudioClip> intro => new List<AudioClip>() { _egyptIntro, _renaissanceIntro, _samouraiIntro, _hackermanIntro };
    public List<AudioClip> main => new List<AudioClip>() { _egyptMain, _renaissanceMain, _samouraiMain, _hackermanMain };

}
