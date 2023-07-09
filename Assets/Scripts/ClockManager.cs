using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class ClockManager : MonoBehaviour
{
    public float startTime = 7.5f; //7:30 AM
    public float endTime = 16; //4:00 PM
    public float timeSpeed = 1;
    public TextMeshProUGUI clock;

    private float actualTime;
    private float currentTime;

    // Update is called once per frame
    void Update()
    {   
        if(actualTime <= endTime)
        {
            currentTime += Time.deltaTime * timeSpeed/100;
            actualTime = currentTime + startTime;

            Debug.Log(actualTime);

            DateTime timeText = DateTime.Today.AddHours(actualTime);
            string formatHour = timeText.ToString("h:mm tt");
            clock.text = formatHour;
        }

        else
        {
            if(ScoreManager.instance.IsGoalMet())
                ScreensManager.instance.SetActive("Shop");
            else
                ScreensManager.instance.SetActive("GameOver");
        }
    }
}