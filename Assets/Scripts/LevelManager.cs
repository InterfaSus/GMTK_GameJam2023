using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    public void NextLevel() {

        Persistents.Level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
