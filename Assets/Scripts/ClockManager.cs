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
    public AudioSource alarm;
    public TextMeshProUGUI dayText;


    private float actualTime;
    private float currentTime;
    private bool running = true;
    private bool alreadyPlayed = false;

    void Start() {

        if(!Persistents.DidTutorial) dayText.text = $"Day 0";
        else dayText.text = $"Day {Persistents.Level}";
    }

    // Update is called once per frame
    void Update()
    {   
        if (!running) return;
        
        if(actualTime <= endTime)
        {
            float tutorialFactor = 1;
            if(!Persistents.DidTutorial) tutorialFactor = 0;
            currentTime += Time.deltaTime * tutorialFactor * (timeSpeed - Persistents.upgradeLevels[3] / 2) / 100.0f;
            actualTime = currentTime + startTime;


            DateTime timeText = DateTime.Today.AddHours(actualTime);
            string formatHour = timeText.ToString("hh:mm tt");

            if(timeText.Minute % 15 == 0) clock.text = formatHour;
        }
        else
        {   
            if(!alreadyPlayed)
            {
                alreadyPlayed = true;
                alarm.Play();
            }

            if(!alarm.isPlaying)
            {
                running = false;
                Persistents.currentScore += GetComponent<ScoreManager>().currentScore;

                if(ScoreManager.instance.IsGoalMet())
                    if(Persistents.Level < 5)
                        ScreensManager.instance.SetActive("shop");
                    else LevelManager.instance.NextLevel();
                else {

                    ScreensManager.instance.SetActive("game_over");
                }
            }
        }
    }


    //For debugging
    public void FinishDay()
    {
        currentTime = 8.5f;
    }

    
}