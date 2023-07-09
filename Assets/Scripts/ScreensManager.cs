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
    }

    public void SetActive(string name)
    {
        foreach (Page page in pages)
        {
            if (page.name == name)
            {
                page.gameObject.SetActive(true);
            }
            else
            {
                page.gameObject.SetActive(false);
            }
        }
    }

    
}
