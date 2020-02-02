using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "fontSize")]
public class FontSizeCollection : ScriptableObject
{
    [SerializeField] protected int _egypt;
    [SerializeField] protected int _renaissance;
    [SerializeField] protected int _samourai;
    [SerializeField] protected int _hackerman;

    public List<int> list => new List<int>() { _egypt, _renaissance, _samourai, _hackerman };
}
