using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    [SerializeField] private WindowSprites _sprites = null;

    private void Start()
    {
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.era];
        PlaceWindowRandomly();       
    }

    private void PlaceWindowRandomly()
    {
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        Rect rect = GetComponent<RectTransform>().rect;
        float horPos = Random.Range(-screenWidth / 2 + rect.width / 2, screenWidth / 2 - rect.width / 2);
        float vertPos = Random.Range(-screenWidth / 2 + rect.height / 2, screenHeight / 2 - rect.height / 2);

        GetComponent<RectTransform>().localPosition = new Vector3(horPos, vertPos, 0);
    }
}
