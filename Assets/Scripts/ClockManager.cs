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
    private bool running = true;

    // Update is called once per frame
    void Update()
    {   
        if (!running) return;

        if(actualTime <= endTime)
        {
            currentTime += Time.deltaTime * timeSpeed/100;
            actualTime = currentTime + startTime;


            DateTime timeText = DateTime.Today.AddHours(actualTime);
            string formatHour = timeText.ToString("hh:mm tt");

            if(timeText.Minute % 15 == 0) clock.text = formatHour;
        }

        else
        {   
            running = false;
            Persistents.currentScore += GetComponent<ScoreManager>().currentScore;

            if(ScoreManager.instance.IsGoalMet())
                ScreensManager.instance.SetActive("shop");
            else
                ScreensManager.instance.SetActive("game_over");
        }
    }
}