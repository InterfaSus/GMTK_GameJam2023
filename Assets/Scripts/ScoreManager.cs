using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

    public int goalScore = 100;
    int currentScore = 0;

    void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int amount) {

        currentScore += amount;
        scoreText.text = currentScore.ToString() + "/" + goalScore.ToString();
    }

    public bool IsGoalMet() => currentScore >= goalScore;
    
}
