using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TimeShifter timeShifter;
    
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
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        BackToMainMenu();
        LeaveGame();
    }
}
