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

        StartCoroutine(FadeFromBlack());
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

    public void NextLevel() {

        
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

    public void RestartGame() {
            
        SceneManager.LoadScene(1);
    }

    public void MainMenu() {

        SceneManager.LoadScene(0);
    }
}
