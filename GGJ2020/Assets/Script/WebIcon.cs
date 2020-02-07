using UnityEngine;
using UnityEngine.UI;

public class WebIcon : MonoBehaviour
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] private IconSprites _icons = null;
    [SerializeField] private Sprite _hackermanPopUp = null;

    private SoundRandomiser _audioSource;

    private void Start()
    {
        if (TimeShifter.CurrentEra != (int)Era.Renaissance && TimeShifter.CurrentEra != (int)Era.Hackerman)
            Destroy(gameObject);
        _audioSource = GetComponent<SoundRandomiser>();
        GetComponent<Image>().sprite = _icons.list[TimeShifter.CurrentEra];
    }

    public void OnClick()
    {
        if(TimeShifter.CurrentEra == (int)Era.Renaissance)
        {
            _audioSource.Play();
        }
        if (TimeShifter.CurrentEra == (int)Era.Hackerman)
        {
            Window instance = Instantiate(_windowPrefab, transform.parent.parent);
            Image img = instance.transform.GetChild(0).GetComponent<Image>();
            img.sprite = _hackermanPopUp;
            RectTransform imgRect = img.GetComponent<RectTransform>();
            RectTransform instRect = instance.GetComponent<RectTransform>();
            imgRect.sizeDelta = new Vector2(instRect.rect.width, instRect.rect.height) * 0.8f;
        }

    }
}