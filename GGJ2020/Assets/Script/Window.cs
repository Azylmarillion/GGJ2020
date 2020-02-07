using UnityEngine;
using UnityEngine.UI;

public class Window : ChangeOnTimeShift
{
    [SerializeField] 
        WindowSprites _sprites = null;
    Canvas canvas = null;
    EditorNeonWindows scriptNeonloaded = null;
    Image image = null;
    Material defaultMaterial = null;
    

    void PlaceWindowRandomly()
    {
        float _canvasWidth = canvas.pixelRect.width;
        float _canvasHeight = canvas.pixelRect.height;

        Rect rect = GetComponent<RectTransform>().rect;
        float horPos = Random.Range(-_canvasWidth / 2 + rect.width / 2, _canvasWidth / 2 - rect.width / 2);
        float vertPos = Random.Range(-_canvasHeight / 2 + rect.height / 2, _canvasHeight / 2 - rect.height / 2);

        GetComponent<RectTransform>().localPosition = new Vector3(horPos, vertPos, 0);

        if (TimeShifter.CurrentEra == (int)Era.Hackerman)
        {
            MakeItGlow();
        }
        else
        {
            if (image.GetComponent<EditorNeonWindows>())
            {
                Destroy(scriptNeonloaded.gameObject);
                image.material = defaultMaterial;
            }
        }
        
    }

    void MakeItGlow()
    {
        image.material = Resources.Load<Material>("MAAT_Glow");
        image.gameObject.AddComponent<EditorNeonWindows>();
        scriptNeonloaded = image.GetComponent<EditorNeonWindows>();
    }

    public override void OnTimeShift()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        image = GetComponent<Image>();
        defaultMaterial = image.material;
        canvas = FindObjectOfType<Canvas>();
        GetComponent<Image>().sprite = _sprites.list[TimeShifter.CurrentEra];
        PlaceWindowRandomly();
        GetComponent<SoundRandomiser>().Play();
    }
}