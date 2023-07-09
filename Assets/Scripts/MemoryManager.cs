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

    bool isInFront = false;

    void Start() {
        LoadRulesMemory(new string[] {});
    }

    void Update() {

        if(Input.GetMouseButtonDown(1)) {
            if (isInFront) {
                isInFront = false;
                memoryPanel.transform.SetAsFirstSibling();
            }
            else {
                isInFront = true;
                memoryPanel.transform.SetAsLastSibling();
            }
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
