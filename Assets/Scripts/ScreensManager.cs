using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScreensManager : MonoBehaviour
{
    public static ScreensManager instance;
    
    public List<Page> pages;
    
    public AudioSource GameOver;
    public AudioSource Shop;
    public AudioSource Victory;

    public AudioSource BGMusic;
    public float BGMusicVolume = 0.1f;


    public Image blackFade;



    void Awake()
    {
        instance = this;
    }

    void Update() 
    {
        if (BGMusic.time >= 32f)
        {
            BGMusic.time = 0f;
        }    
    }
    public void StartLevel()
    {
        BGMusic.Play();
        StartCoroutine(FadeFromBlack(instance.BGMusic, BGMusicVolume));
    }

    public void SetActive(string name)
    {
        AudioSource music;
        
        if(name == "shop") music = Shop;
        else if(name == "game_over") music = GameOver;
        else music = Victory;

        StartCoroutine(FadeTo(name, music));
    }

    IEnumerator FadeFromBlack(AudioSource music, float volume) {
        
        float alpha = 3;


        while (alpha > 0) {
            alpha -= Time.deltaTime;
            if (alpha < 0) alpha = 0;
            blackFade.color = new Color(0, 0, 0, alpha);

            music.volume = Mathf.Lerp(volume, 0, alpha/3);

            yield return null;
        }
    }

    IEnumerator FadeTo(string name, AudioSource music) {
            
        float alpha = 0;
        
        float volume = music.volume;

        music.Play();

        while (alpha < 1) {

            alpha += Time.deltaTime * Persistents.fadeSpeed;
            blackFade.color = new Color(0, 0, 0, alpha);

            music.volume = Mathf.Lerp(0, volume, alpha);
            BGMusic.volume = Mathf.Lerp(BGMusicVolume, 0, alpha);

            yield return null;
        }

        
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

        StartCoroutine(FadeFromBlack(music, volume));
    }
}
