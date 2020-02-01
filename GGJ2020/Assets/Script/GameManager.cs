﻿using UnityEngine;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeEra(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeEra(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeEra(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeEra(3);
    }
}
