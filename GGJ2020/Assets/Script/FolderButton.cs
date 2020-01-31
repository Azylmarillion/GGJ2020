using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderButton: MonoBehaviour
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] private ImageIcon _imageIconPrefab = null;
    [SerializeField] private List<Sprite> _imageInside = null;

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent);
        Rect instanceRect = instance.GetComponent<RectTransform>().rect;
        for (int i = 0; i < _imageInside.Count; i++)
        {          
            //place image icon
            ImageIcon iconInstance = Instantiate(_imageIconPrefab, instance.transform);
            RectTransform iconRect = iconInstance.GetComponent<RectTransform>();
            Vector3 spawnPos = new Vector3(
                -instanceRect.width / 2 + iconRect.rect.width/2,
                instanceRect.height / 2 - iconRect.rect.height/2,
                0);
            iconRect.localPosition = spawnPos;

            //fill ImageIcon component
            iconInstance.SetSprite(_imageInside[i]);
        }        
    }
}

