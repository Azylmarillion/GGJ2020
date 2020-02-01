using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : ChangeOnTimeShift
{
    #region F/P
    [SerializeField]
    PointerSprites pointerSpritesCollection = null;

    #endregion

    void Start()
    {
        
    }

    public override void OnTimeShift()
    {

    }
}