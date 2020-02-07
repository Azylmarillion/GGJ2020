using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Icon : ChangeOnTimeShift
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] private IconSprites _sprites = null;
    [SerializeField] private FontsCollection _fonts = null;
    [SerializeField] private FontSizeCollection _fontSizes = null;

    public Sprite associatedSprite { get; private set; }
    public string associatedText { get; private set; }

    private void Start()
    {
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.CurrentEra];
    }

    public void SetAttachedSprite(Sprite toAttach)
    {
        associatedSprite = toAttach;
    }

    public void SetAttachedText(string toAttach)
    {
        associatedText = toAttach;
    }

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent.parent);
        RectTransform[] children = instance.GetComponentsInChildren<RectTransform>();
        float scale = 0.7f;
        if (associatedSprite != null)
        {
            Image img = children[1].GetComponentInChildren<Image>();
            img.enabled = true;
            img.GetComponent<RectTransform>().sizeDelta = new Vector2(
                children[0].rect.width * scale,
                children[0].rect.height * scale);
            img.sprite = associatedSprite;
        }
        else
        {
            children[1].GetComponentInChildren<Image>().enabled = false;
        }

        if (associatedText != null)
        {
            TextMeshProUGUI txt = instance.GetComponentInChildren<TextMeshProUGUI>();
            txt.GetComponent<RectTransform>().sizeDelta = new Vector2(
                instance.GetComponent<RectTransform>().rect.width * scale,
                instance.GetComponent<RectTransform>().rect.height * scale);
            txt.text = associatedText;
            txt.font = _fonts.list[TimeShifter.CurrentEra];
            txt.fontSize = _fontSizes.list[TimeShifter.CurrentEra];
        }
    }

    public override void OnTimeShift()
    {
        associatedSprite = null;
        associatedText = null;
    }
}

