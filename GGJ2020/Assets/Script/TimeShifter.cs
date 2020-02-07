using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeShifter
{
    private static Era _currentEra;
    public static int CurrentEra
    {
        get
        {
            return (int)_currentEra;
        }
    }

    public TimeShifter()
    {
        ChangeEra(Era.Hackerman);
    }

    public void ChangeEra(Era newEra)
    {
        if (newEra == Era.EndScene)
            SceneManager.LoadScene(2);
        _currentEra = newEra;
        foreach (var obj in Object.FindObjectsOfType<ChangeOnTimeShift>())
            obj.OnTimeShift();
    }    
}

public enum Era
{
    EndScene = -1,
    Egypt = 0,
    Renaissance = 1,
    Samourai = 2,
    Hackerman = 3    
}