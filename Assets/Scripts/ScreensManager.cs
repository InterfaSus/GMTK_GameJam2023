using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;
    public List<Page> pages;

    void Awake()
    {
        instance = this;

        //print all pages names
        foreach (Page page in pages)
        {
            Debug.Log(page.name);
        }
    }

    public void SetActive(string name)
    {
        foreach (Page page in pages)
        {
            if (page.pageName == name)
            {
                page.gameObject.SetActive(true);
                Debug.Log(name + " is active");
            }
            else
            {
                page.gameObject.SetActive(false);
            }
        }
    }

    
}
