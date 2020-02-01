using UnityEngine;

public class TimeShifter
{
    private static Era _currentEra;
    public static int era => (int)_currentEra;

    public TimeShifter()
    {
        ChangeEra(Era.Hackerman);
    }

    public void ChangeEra(Era newEra)
    {
        _currentEra = newEra;
        foreach (var obj in Object.FindObjectsOfType<ChangeOnTimeShift>())
            obj.OnTimeShift();
    }

    
}

public enum Era
{
    Egypt = 0,
    Renaissance = 1,
    Samourai = 2,
    Hackerman = 3
}