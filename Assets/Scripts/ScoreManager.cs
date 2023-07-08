using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;

    int goalScore = 100;
    int currentScore = 0;

    public void UpdateScore(int amount) {

        currentScore += amount;
        scoreText.text = currentScore.ToString() + "/" + goalScore.ToString();
    }
}
