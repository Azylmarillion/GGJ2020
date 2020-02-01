using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private TimeShifter timeShifter;
    
    void Start()
    {
        timeShifter = new TimeShifter();
    }

    public void ChangeEra(int newEra)
    {
        timeShifter.ChangeEra((Era)newEra);
    }
}
