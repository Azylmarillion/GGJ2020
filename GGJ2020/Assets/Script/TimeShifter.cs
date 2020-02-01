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
        FolderIcon[] folders = Object.FindObjectsOfType<FolderIcon>();

    }
}

public enum Era
{
    Egypt = 0,
    Renaissance = 1,
    Samourai = 2,
    Hackerman = 3
}