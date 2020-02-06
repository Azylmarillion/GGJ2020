using UnityEngine;
using UnityEngine.UI;

public class Window : ChangeOnTimeShift
{
    [SerializeField] 
        WindowSprites _sprites = null;
    Canvas canvas = null;
    

    void PlaceWindowRandomly()
    {
        float _canvasWidth = canvas.pixelRect.width;
        float _canvasHeight = canvas.pixelRect.height;

        Rect rect = GetComponent<RectTransform>().rect;
        float horPos = Random.Range(-_canvasWidth / 2 + rect.width / 2, _canvasWidth / 2 - rect.width / 2);
        float vertPos = Random.Range(-_canvasHeight / 2 + rect.height / 2, _canvasHeight / 2 - rect.height / 2);

        GetComponent<RectTransform>().localPosition = new Vector3(horPos, vertPos, 0);
    }

    void MakeItGlow()
    {
        /*
         * if enum era == hackermantime 
         * load glow material + script neoneditor
         * set param neon editor color  + pulse
         */
    }

    public override void OnTimeShift()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.era];
        PlaceWindowRandomly();
        GetComponent<SoundRandomiser>().Play();
    }
}