using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageIcon : MonoBehaviour
{
    [SerializeField] private Window _windowPrefab = null;

    public Sprite associatedSprite { get; private set; }

    public void SetSprite(Sprite toAttach)
    {
        associatedSprite = toAttach;
    }

    public void OnClick()
    {
        Window instance = Instantiate(_windowPrefab, transform.parent);
        instance.GetComponent<Image>().sprite = associatedSprite;
    }
}
