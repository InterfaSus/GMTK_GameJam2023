using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    
    public Image blackFade;

    void Start() {

        ScreensManager.instance.StartLevel();
    }

   
    IEnumerator FadeFromBlack() {
        
        float alpha = 1;
        while (alpha > 0) {
            alpha -= Time.deltaTime;
            if (alpha < 0) alpha = 0;
            blackFade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeToBlack(int scene) {
            
        float alpha = 0;
        while (alpha < 1) {
            alpha += Time.deltaTime * Persistents.fadeSpeed;
            blackFade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(scene);
    }

    IEnumerator AdvanceLevel() {

        float alpha = 0;
        while (alpha < 1) {
            alpha += Time.deltaTime * Persistents.fadeSpeed * 0.2f;
            blackFade.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        if(Persistents.Level < 5)
        {
            Persistents.Level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        else
        {
            ScreensManager.instance.SetActive("victory");
        }
    }

    public void NextLevel() {

        StartCoroutine(AdvanceLevel());
    }

    public void RestartGame() {
            
        StartCoroutine(FadeToBlack(1));
    }

    public void MainMenu() {

        StartCoroutine(FadeToBlack(0));
    }
}
