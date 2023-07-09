using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    
    public GameObject continueButton;

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

        SceneManager.LoadScene(1);
    }

    public void Exit() {

        Application.Quit();
    }
}
