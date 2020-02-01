using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderIcon: MonoBehaviour
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] private Icon _imgIconPrefab = null;
    [SerializeField] private Icon _txtIconPrefab = null;
    [SerializeField] private FolderSprites _folderSprites = null;
    [SerializeField] private List<Sprite> _imgEgyptContent = null;
    [SerializeField] private List<Sprite> _imgRenaissanceContent = null;
    [SerializeField] private List<Sprite> _imgSamouraiContent = null;
    [SerializeField] private List<Sprite> _imgHackermanContent = null;
    [SerializeField] private List<Sprite> _txtEgyptContent = null;
    [SerializeField] private List<Sprite> _txtRenaissanceContent = null;
    [SerializeField] private List<Sprite> _txtSamouraiContent = null;
    [SerializeField] private List<Sprite> _txtHackermanContent = null;

    private List<List<Sprite>> _imgContent = null;
    private List<List<Sprite>> _txtContent = null;


    public void OnEnable()
    {
        GetComponent<Image>().sprite = _folderSprites.list[TimeShifter.era];
    }

    public void Start()
    {
        _imgContent = new List<List<Sprite>>()
                { _imgEgyptContent, _imgRenaissanceContent, _imgSamouraiContent, _imgHackermanContent };
        _txtContent = new List<List<Sprite>>()
                { _txtEgyptContent, _txtRenaissanceContent, _txtSamouraiContent, _txtHackermanContent };
    }

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent);
        Rect instanceRect = instance.GetComponent<RectTransform>().rect;

        int currentIcon = 0;

        //Place img icon
        for (int i = 0; i < _imgContent[TimeShifter.era].Count; i++)
        {          
            Icon iconInstance = Instantiate(_imgIconPrefab, instance.transform);
            RectTransform iconRect = iconInstance.GetComponent<RectTransform>();
            Vector3 spawnPos = new Vector3(
                -instanceRect.width / 2 + iconRect.rect.width/2 + currentIcon * iconRect.rect.width,
                instanceRect.height / 2 - iconRect.rect.height/2,
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
                -instanceRect.width / 2 + iconRect.rect.width / 2 + currentIcon * iconRect.rect.width,
                instanceRect.height / 2 - iconRect.rect.height / 2,
                0);
            iconRect.localPosition = spawnPos;

            iconInstance.SetAttachedSprite(_txtContent[TimeShifter.era][i]);

            currentIcon++;
        }
    }
}

