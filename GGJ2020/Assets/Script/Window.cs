using UnityEngine;
using UnityEngine.UI;

public class Window : ChangeOnTimeShift
{
    [SerializeField] 
        WindowSprites _sprites = null;
    Canvas canvas = null;
    

    private void PlaceWindowRandomly()
    {
        float screenWidth = canvas.pixelRect.width;
        float screenHeight = canvas.pixelRect.height;

        Rect rect = GetComponent<RectTransform>().rect;
        float horPos = Random.Range(-screenWidth / 2 + rect.width / 2, screenWidth / 2 - rect.width / 2);
        float vertPos = Random.Range(-screenHeight / 2 + rect.height / 2, screenHeight / 2 - rect.height / 2);

        GetComponent<RectTransform>().localPosition = new Vector3(horPos, vertPos, 0);
    }

    public override void OnTimeShift()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.era];
        PlaceWindowRandomly();
        GetComponent<SoundRandomiser>().Play();
    }
}