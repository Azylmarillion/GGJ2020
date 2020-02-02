using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HackTime : ChangeOnTimeShift
{
    [SerializeField] private FontsCollection _fonts = null;
    [SerializeField] private FontSizeCollection _fontSize = null;
    [SerializeField] private int _idxStep = 0;
    [SerializeField] private float successPercentage = 0;
    [SerializeField] private TextAsset _hackText = null;

    private TextMeshProUGUI text;
    int maxIdx = 0;
    int currentIdx = 0;
    int desiredIdx = 0;
    private bool transitionStarted;

    public override void OnTimeShift()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.font = _fonts.list[TimeShifter.era];
        text.fontSize = _fontSize.list[TimeShifter.era];
        currentIdx = 0;
        desiredIdx = 0;
        maxIdx = _hackText.text.Length - 10;
        transitionStarted = false;
    }

    public void Update()
    {
        text.text = "#it's hack time! \n" + _hackText.text.Substring(0, currentIdx);
        if (Input.anyKeyDown)
        {
            desiredIdx += _idxStep;
            StartCoroutine(WriteHackText());
        }       
    }

    private IEnumerator WriteHackText()
    {
        if (currentIdx >= maxIdx)
        {
            currentIdx = maxIdx;
            yield return null;
        }

        while(currentIdx <= desiredIdx)
        {
            if (currentIdx > maxIdx)
            {
                yield return null;
                currentIdx = maxIdx;
            }
            if(UnityEngine.Random.Range(0.0f, 1.0f) < successPercentage)
                currentIdx++;
            if (currentIdx == maxIdx && !transitionStarted)
            {
                transitionStarted = true;              
                GlitchTransition();
            }
            yield return null;
        }
    }

    private void GlitchTransition()
    {
        StopAllCoroutines();
        Camera.main.GetComponent<GlitchTransition>().Glitch();
    }
}
