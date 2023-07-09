using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;
    public List<Page> pages;
    public AudioSource GameOver;
    public AudioSource Shop;
    public AudioSource Victory;


    void Awake()
    {
        instance = this;
    }

    public void SetActive(string name)
    {
        if(name == "shop") Shop.Play();
        if(name == "game_over") GameOver.Play();
        if(name == "victory") Victory.Play();

        foreach (Page page in pages)
        {
            if (page.pageName == name)
            {
                page.gameObject.SetActive(true);
                if (page.pageName == "shop") FindObjectOfType<ShopManager>().UpdateShop();
            }
            else
            {
                page.gameObject.SetActive(false);
            }
        }
    }

    
}
