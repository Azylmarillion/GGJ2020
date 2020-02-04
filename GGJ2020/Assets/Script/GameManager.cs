using UnityEngine;
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

    void Start()
    {
        timeShifter = new TimeShifter();
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

    void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
    }

    void OnDestroy()
    {
        if (instance = this)
            instance = null;
    }

    void Update()
    {
        BackToMainMenu();
        LeaveGame();
    }
}