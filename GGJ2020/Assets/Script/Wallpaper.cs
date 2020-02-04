using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Wallpaper : ChangeOnTimeShift
{

    [SerializeField] private WallPaperSprites _sprites = null;

    private Image attachedImage;

    public override void OnTimeShift()
    {
        if(attachedImage == null)
            attachedImage = GetComponent<Image>();
        attachedImage.sprite = _sprites.list[TimeShifter.era];
    }

    void Start()
    {
        attachedImage = GetComponent<Image>();
        //Scale image
        //attachedImage.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.height * 4/3, Screen.height);
    }    
}