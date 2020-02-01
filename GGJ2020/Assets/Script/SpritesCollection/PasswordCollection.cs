using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "passwordCollection")]
public class PasswordCollection : ScriptableObject
{
    [SerializeField] protected string _egypt;
    [SerializeField] protected string _renaissance;
    [SerializeField] protected string _samourai;
    [SerializeField] protected string _hackerman;

    public List<string> list => new List<string>() { _egypt, _renaissance, _samourai, _hackerman };
}
