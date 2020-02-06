using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TimeShifter timeShifter;

    static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }   

    public void ChangeEra()
    {
        timeShifter.ChangeEra((Era)(TimeShifter.era - 1));
    }

    public void ChangeEra(int newEra)
    {
        timeShifter.ChangeEra((Era)newEra);
    }

    void BackToMainMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void LeaveGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Input.GetKeyDown(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Application.Quit();
        }
    }

    void SetScreenResolution(float _width, float _height)
    {
        float _heightRatio = (_width / _height) / (4f/3f);

        if(_heightRatio == 1)
        {
            Camera.main.rect = new Rect(0, 0, 1, 1);
        }
        else if(_heightRatio < 1)
        {
            Camera.main.rect = new Rect(0, (1 - _heightRatio) / 2, 1, _heightRatio);
        }
        else
        {
            float _widthRatio = 1 / _heightRatio;
            Camera.main.rect = new Rect((1 - _widthRatio) / 2, 0, _widthRatio, 1);
        }
    }

    void SetScreenResolution(Scene _scene, LoadSceneMode _mode)
    {
        float _height = Screen.height;
        float _width = Screen.width;

        float _heightRatio = (_width / _height) / (4f / 3f);

        if (_heightRatio == 1)
        {
            Camera.main.rect = new Rect(0, 0, 1, 1);
        }
        else if (_heightRatio < 1)
        {
            Camera.main.rect = new Rect(0, (1 - _heightRatio) / 2, 1, _heightRatio);
        }
        else
        {
            float _widthRatio = 1 / _heightRatio;
            Camera.main.rect = new Rect((1 - _widthRatio) / 2, 0, _widthRatio, 1);
        }
    }

    void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        SetScreenResolution(Screen.width,Screen.height);
        SceneManager.sceneLoaded += SetScreenResolution;
    }

    void OnDestroy()
    {
        if (instance = this)
            instance = null;
    }

    void Start()
    {
        timeShifter = new TimeShifter();
    }

    void Update()
    {
        BackToMainMenu();
        LeaveGame();
    }
}