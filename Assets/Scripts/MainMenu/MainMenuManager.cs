using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenuManager : MonoBehaviour
{
    
    public GameObject continueButton;
    public Image blackFade;

    void Start() {

        if(Persistents.Level > 1) continueButton.SetActive(true);
        else continueButton.SetActive(false);
    }

    public void PlayGame(bool reset) {

        if (reset) {
            Persistents.Level = 1;
            Persistents.currentScore = 0;
            Persistents.upgradeLevels = new int[5];
        }

        StartCoroutine(FadeToBlack());

        // SceneManager.LoadScene(1);
    }

    IEnumerator FadeToBlack() {
            
        float alpha = 0;
        while (alpha < 1) {
            alpha += Time.deltaTime * Persistents.fadeSpeed;
            blackFade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(1);
    }

    public void Exit() {

        Application.Quit();
    }
}
