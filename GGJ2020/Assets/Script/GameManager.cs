using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private TimeShifter timeShifter;
    
    void Awake()
    {
        timeShifter = new TimeShifter();
    }

    void Update()
    {

    }
}
