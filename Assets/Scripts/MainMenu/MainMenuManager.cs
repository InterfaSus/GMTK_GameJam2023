using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    
    public GameObject continueButton;
    public Image blackFade;
    public AudioSource music;

    void Start() {

        if(Persistents.Level > 1) {

            continueButton.SetActive(true);
            continueButton.GetComponentInChildren<TextMeshProUGUI>().text = $"Continue Day {Persistents.Level}";
        }
        else continueButton.SetActive(false);
        StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeFromBlack() {
        
        float alpha = 3;

        float finalVolume = music.volume;

        while (alpha > 0) {
            alpha -= Time.deltaTime;
            if (alpha < 0) alpha = 0;
            blackFade.color = new Color(0, 0, 0, alpha);

            music.volume = Mathf.Lerp(finalVolume, 0, alpha);

            yield return null;
        }
    }

    public void PlayGame(bool reset) {

        if (reset) {
            Persistents.Level = 1;
            Persistents.currentScore = 0;
            Persistents.upgradeLevels = new int[5];
        }

        StartCoroutine(FadeToBlack());
    }

    IEnumerator FadeToBlack() {
            
        float alpha = 0;
        
        float startVolume = music.volume;

        while (alpha < 1) {

            alpha += Time.deltaTime * Persistents.fadeSpeed;
            blackFade.color = new Color(0, 0, 0, alpha);

            music.volume = Mathf.Lerp(startVolume, 0, alpha);

            yield return null;
        }

        SceneManager.LoadScene(1);
    }

    public void Exit() {

        Application.Quit();
    }
}
