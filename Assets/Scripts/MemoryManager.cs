using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{   

    public GameObject rulesContainer;
    public GameObject memoryPanel;
    public GameObject memoryContent;
    public GameObject splitTextPrefab;

    public AudioSource BGMusic;

//Arreglar esto quee esta hardcodeado por ahora
    public float minVolume = 0.1f;
    public float maxVolume = 0.5f;
    bool isInFront = false;

    void Start() {
        LoadRulesMemory(new string[] {});
    }

    void Update() {

        if(Input.GetMouseButtonDown(1)) {
            RaiseVolume(true);
            isInFront = true;
            memoryPanel.transform.SetAsLastSibling();
        }
        else if (Input.GetMouseButtonUp(1)) {
            RaiseVolume(false);
            isInFront = false;
            memoryPanel.transform.SetAsFirstSibling();
        }
    }

    //Increase or Decrease the volume to the max gradually
    private void RaiseVolume(bool Raise)
    {
        if (Raise)
            StartCoroutine(FadeTo(maxVolume));
        else
            StartCoroutine(FadeTo(minVolume));
    }

    private IEnumerator FadeTo(float volume)
    {
        float alpha = 0;
        float startVolume = BGMusic.volume;


        while (alpha < 1)
        {
            alpha += Time.deltaTime * Persistents.memoryFadeSpeed;
            BGMusic.volume = Mathf.Lerp(startVolume, volume, alpha);

            yield return null;
        }
    }

    public void LoadRulesMemory(string[] rules) {
        
        foreach (Transform child in memoryContent.transform) {
            Destroy(child.gameObject);
        }

        if (rules.Length == 0) {
            GameObject splitText = Instantiate(splitTextPrefab, memoryContent.transform);
                        splitText.GetComponent<SeparateLetters>().InitializeLetters("MARK THE RULES YOU WANT TO REMEMBER");
        }

        foreach (var rule in rules) {
            GameObject splitText = Instantiate(splitTextPrefab, memoryContent.transform);
            splitText.GetComponent<SeparateLetters>().InitializeLetters(rule);
        }
    }
}
