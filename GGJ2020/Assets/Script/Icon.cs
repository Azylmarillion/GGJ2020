using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] private Window _windowPrefab = null;
    [SerializeField] IconSprites sprites = null;

    public Sprite associatedSprite { get; private set; }

    private void Start()
    {
        GetComponent<Image>().sprite = sprites.list[TimeShifter.era];
    }

    public void SetAttachedSprite(Sprite toAttach)
    {
        associatedSprite = toAttach;
    }

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent);
        instance.GetComponent<Image>().sprite = associatedSprite;
    }
}

