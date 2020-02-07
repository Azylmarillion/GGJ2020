using UnityEngine;

public class CursorManager : ChangeOnTimeShift
{
    #region F/P
    [SerializeField]
    PointerSprites pointerSpritesCollection = null;

    #endregion

    #region Meths
    #region MyMeths
    #endregion
    #region HeritageMeths
    public override void OnTimeShift()
    {
        if (pointerSpritesCollection == null)
        {
            Debug.Log("need pointersCollection script");
            return;
        }
            Cursor.SetCursor(pointerSpritesCollection.list[TimeShifter.CurrentEra], Vector2.zero, CursorMode.Auto);
        
    }
    #endregion
    #endregion
}