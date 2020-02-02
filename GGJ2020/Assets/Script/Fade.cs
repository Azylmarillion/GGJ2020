using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private float timeToFade = 0.0f;

    Image[] toFade;
    bool isBooting;
    float fadeJump;

    private void OnEnable()
    {
        fadeJump = 1 / (60 * timeToFade);
        toFade = GetComponentsInChildren<Image>();
        if(!isBooting)
            StartCoroutine(FadeImage());
    }

    private IEnumerator FadeImage()
    {
        isBooting = true;
        float fadeValue = 0;
        while(fadeValue <= 1)
        {
            foreach (var img in toFade)
            {
                img.color = new Vector4(1, 1, 1, fadeValue);
            }
            fadeValue += fadeJump;
            yield return null;
        }
        
    }
}
