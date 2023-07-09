using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RulesList : MonoBehaviour
{

    public GameObject rulePrefab;
    public TextMeshProUGUI countText;

    RulesManager rulesManager;
    List<Toggle> toggles;
    List<string> rulesNames;
    public int toggleLimit = 4;
    int count = 0;

    void Start() {

        rulesManager = FindObjectOfType<RulesManager>();
    }

    public void InitRuleList() {
        
        if (rulesNames != null) return;
        countText.text = $"{count}/{toggleLimit}";

        toggles = new List<Toggle>();
        rulesNames = new List<string>();
        var rulesList = rulesManager.rules;

        foreach (var rule in rulesList) {
            var ruleObject = Instantiate(rulePrefab, transform);
            ruleObject.GetComponentInChildren<TextMeshProUGUI>().text = rule.Item1;

            Toggle instanceToggle = ruleObject.GetComponentInChildren<Toggle>();
            
            toggles.Add(instanceToggle);

            rulesNames.Add(ruleObject.GetComponentInChildren<TextMeshProUGUI>().text);
        }
    }

    public void ClickToggle(bool value) {

    }

    public void CloseList() {

        List<string> activeRules = new List<string>();

        for (int i = 0; i < toggles.Count; i++) {
            if (toggles[i].isOn) {
                activeRules.Add(rulesNames[i]);
            }
        }

        FindObjectOfType<MemoryManager>().LoadRulesMemory(activeRules.ToArray());
    }
}
