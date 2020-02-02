using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "clipCollecion")]
public class ClipsCollection : ScriptableObject
{
    [SerializeField] protected AudioClip _egypt;
    [SerializeField] protected Vector2 _pitchEgypt = new Vector2(0.85f, 1.15f);
    [SerializeField] protected Vector2 _volumeEgypt = new Vector2(0.9f, 1.0f);

    [SerializeField] protected AudioClip _renaissance;
    [SerializeField] protected Vector2 _pitchRenaissance = new Vector2(0.85f, 1.15f);
    [SerializeField] protected Vector2 _volumeRenaissance = new Vector2(0.9f, 1.0f);

    [SerializeField] protected AudioClip _samourai;
    [SerializeField] protected Vector2 _pitchSamourai = new Vector2(0.85f, 1.15f);
    [SerializeField] protected Vector2 _volumeSamourai = new Vector2(0.9f, 1.0f);

    [SerializeField] protected AudioClip _hackerman;
    [SerializeField] protected Vector2 _pitchHackerman = new Vector2(0.85f, 1.15f);
    [SerializeField] protected Vector2 _volumeHackerman = new Vector2(0.9f, 1.0f);


    public List<AudioClip> list => new List<AudioClip>() { _egypt, _renaissance, _samourai, _hackerman };
    public List<Vector2> pitch => new List<Vector2>() { _pitchEgypt, _pitchRenaissance, _pitchSamourai, _pitchHackerman };
    public List<Vector2> volume => new List<Vector2>() { _volumeEgypt, _volumeRenaissance, _volumeSamourai, _volumeHackerman };

}

