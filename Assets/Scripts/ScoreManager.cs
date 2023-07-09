using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TextMeshProUGUI scoreText;

    public int goalScore;
    public int currentScore = 0;

    void Start()
    {
        instance = this;
        goalScore = Persistents.GoalScore[Persistents.Level - 1];
        UpdateScore(0);
    }

    public void UpdateScore(int amount) {

        currentScore += amount;
        if (currentScore < 0) currentScore = 0;
        scoreText.text = currentScore.ToString() + "/" + goalScore.ToString();
    }

    public bool IsGoalMet() => currentScore >= goalScore;
    
}
