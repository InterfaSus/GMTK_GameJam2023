using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryManager : MonoBehaviour
{   

    public GameObject memoryPanel;
    public GameObject memoryContent;
    public GameObject splitTextPrefab;

    void Update() {

        if(Input.GetMouseButtonDown(1)) {
            if (memoryPanel.activeSelf) {
                memoryPanel.SetActive(false);
            }
            else {
                memoryPanel.SetActive(true);
                GetComponent<RulesManager>().rules.ForEach(rule => {
                    GameObject splitText = Instantiate(splitTextPrefab, memoryContent.transform);
                    splitText.GetComponent<SeparateLetters>().InitializeLetters(rule.Item1);
                });
            }
        }
    }
}
