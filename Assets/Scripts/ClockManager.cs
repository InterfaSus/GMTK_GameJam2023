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
    public float timeSpeed = 3.0f;
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
            currentTime += Time.deltaTime * (timeSpeed - Persistents.upgradeLevels[3] / 2) / 100.0f;
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
            else {

                Persistents.Level = 1;
                Persistents.currentScore = 0;
                Persistents.upgradeLevels = new int[5];
                ScreensManager.instance.SetActive("game_over");
            }
        }

        //For debugging
        public void FinishDay()
        {
            actualTime = endTime;
        }
    }
}