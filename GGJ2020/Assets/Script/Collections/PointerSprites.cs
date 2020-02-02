using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Texture2D/pointerSprite")]
public class PointerSprites : ScriptableObject
{
    [SerializeField] 
        protected Texture2D _egypt;
    [SerializeField] 
        protected Texture2D _renaissance;
    [SerializeField] 
        protected Texture2D _samourai;
    [SerializeField] 
        protected Texture2D _hackerman;

    public List<Texture2D> list => new List<Texture2D>() { _egypt, _renaissance, _samourai, _hackerman };
}