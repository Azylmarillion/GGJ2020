using System.Collections.Generic;
using UnityEngine;


public abstract class SpritesCollection : ScriptableObject
{
    [SerializeField] protected Sprite _egypt;
    [SerializeField] protected Sprite _renaissance;
    [SerializeField] protected Sprite _samourai;
    [SerializeField] protected Sprite _hackerman;

    public List<Sprite> list => new List<Sprite>() { _egypt, _renaissance, _samourai, _hackerman };
}

