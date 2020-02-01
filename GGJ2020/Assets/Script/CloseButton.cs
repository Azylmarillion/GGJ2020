﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour
{
    [SerializeField] private CloseButtonSprites _sprites = null;

    public void Start()
    {
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.era];
        PlaceCloseButton();
    }

    public void OnClick()
    {
        Destroy(transform.parent.gameObject);
    }

    public void PlaceCloseButton()
    {
        RectTransform parentRect = transform.parent.GetComponent<RectTransform>();
        RectTransform thisRect = GetComponent<RectTransform>();
        thisRect.localPosition = new Vector3(
            parentRect.rect.width / 2 - thisRect.rect.width / 2,
            parentRect.rect.height / 2 - thisRect.rect.height / 2,
            0);
    }
}
