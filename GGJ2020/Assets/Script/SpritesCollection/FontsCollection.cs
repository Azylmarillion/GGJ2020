using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[CreateAssetMenu(menuName = "fontCollection")]
public class FontsCollection : ScriptableObject
{
    [SerializeField] protected TMP_FontAsset _egypt;
    [SerializeField] protected TMP_FontAsset _renaissance;
    [SerializeField] protected TMP_FontAsset _samourai;
    [SerializeField] protected TMP_FontAsset _hackerman;

    public List<TMP_FontAsset> list => new List<TMP_FontAsset>() { _egypt, _renaissance, _samourai, _hackerman };
}
