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

    private HackText hackText = new HackText();
    private TextMeshProUGUI text;
    int maxIdx = 100;
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
        transitionStarted = false;
    }

    public void Update()
    {
        if(currentIdx > maxIdx && !transitionStarted)
        {
            transitionStarted = true;
            GlitchTransition();
        }
        if (Input.anyKeyDown)
        {
            desiredIdx += _idxStep;
            StartCoroutine(WriteHackText());
        }
        text.text = "#it's hack time! \n" + hackText.text.Substring(0, currentIdx);
    }

    private void GlitchTransition()
    {
        Camera.main.GetComponent<GlitchTransition>().Glitch();
    }

    private IEnumerator WriteHackText()
    {
        while(currentIdx <= desiredIdx)
        {
            if(UnityEngine.Random.Range(0.0f, 1.0f) < successPercentage)
                currentIdx++;
            yield return null;
        }
    }
}
