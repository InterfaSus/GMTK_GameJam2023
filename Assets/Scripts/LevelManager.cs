using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
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
