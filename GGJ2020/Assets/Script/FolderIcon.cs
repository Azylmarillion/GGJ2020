using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderIcon: ChangeOnTimeShift
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] private Icon _imgIconPrefab = null;
    [SerializeField] private Icon _txtIconPrefab = null;
    [SerializeField] private PasswordIcon _passwordIconPrefab = null;
    [SerializeField] private FolderSprites _folderSprites = null;
    [SerializeField] private List<Sprite> _imgEgyptContent = null;
    [SerializeField] private List<Sprite> _imgRenaissanceContent = null;
    [SerializeField] private List<Sprite> _imgSamouraiContent = null;
    [SerializeField] private List<Sprite> _imgHackermanContent = null;
    [SerializeField] private List<string> _txtEgyptContent = null;
    [SerializeField] private List<string> _txtRenaissanceContent = null;
    [SerializeField] private List<string> _txtSamouraiContent = null;
    [SerializeField] private List<string> _txtHackermanContent = null;
    [SerializeField] private List<bool> containPasswordExe = null;

    private List<List<Sprite>> _imgContent = null;
    private List<List<string>> _txtContent = null;


    public override void OnTimeShift()
    {
        GetComponent<Image>().sprite = _folderSprites.list[TimeShifter.era];
    }

    public void Awake()
    {
        _imgContent = new List<List<Sprite>>()
                { _imgEgyptContent, _imgRenaissanceContent, _imgSamouraiContent, _imgHackermanContent };
        _txtContent = new List<List<string>>()
                { _txtEgyptContent, _txtRenaissanceContent, _txtSamouraiContent, _txtHackermanContent };
    }

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent);
        instance.transform.GetChild(0).GetComponent<Image>().enabled = false;
        Rect instanceRect = instance.GetComponent<RectTransform>().rect;

        float scale = 0.8f;
        float margin = 50;
        int currentIcon = 0;

        //Place img icon
        for (int i = 0; i < _imgContent[TimeShifter.era].Count; i++)
        {          
            Icon iconInstance = Instantiate(_imgIconPrefab, instance.transform);
            RectTransform iconRect = iconInstance.GetComponent<RectTransform>();
            Vector3 spawnPos = new Vector3(
                -instanceRect.width / 2 + iconRect.rect.width/2 + margin,
                instanceRect.height / 2 - iconRect.rect.height/2,
                0) * scale 
                + new Vector3(
                    (currentIcon % 2) * iconRect.rect.width, 
                    -(currentIcon / 2) * iconRect.rect.height, 
                    0); 
            iconRect.localPosition = spawnPos;

            iconInstance.SetAttachedSprite(_imgContent[TimeShifter.era][i]);

            currentIcon++;
        }
        
        //Place txt icon
        for (int i = 0; i < _txtContent[TimeShifter.era].Count; i++)
        {
            Icon iconInstance = Instantiate(_txtIconPrefab, instance.transform);
            RectTransform iconRect = iconInstance.GetComponent<RectTransform>();
            Vector3 spawnPos = new Vector3(
                -instanceRect.width / 2 + iconRect.rect.width / 2 + margin,
                instanceRect.height / 2 - iconRect.rect.height / 2,
                0) * scale 
                + new Vector3(
                    (currentIcon % 2) * iconRect.rect.width + margin,
                    -(currentIcon / 2) * iconRect.rect.height,
                    0);
            iconRect.localPosition = spawnPos;

            iconInstance.SetAttachedText(_txtContent[TimeShifter.era][i]);

            currentIcon++;
        }

        //Place password icon
        if (containPasswordExe[TimeShifter.era]) 
        {
            PasswordIcon iconInstance = Instantiate(_passwordIconPrefab, instance.transform);
            RectTransform iconRect = iconInstance.GetComponent<RectTransform>();
            Vector3 spawnPos = new Vector3(
                -instanceRect.width / 2 + iconRect.rect.width / 2 + margin,
                instanceRect.height / 2 - iconRect.rect.height / 2,
                0) * scale
                + new Vector3(
                    (currentIcon % 2) * iconRect.rect.width,
                    -(currentIcon / 2) * iconRect.rect.height,
                    0);
            iconRect.localPosition = spawnPos;

            currentIcon++;
        }
    }
}

