using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RulesList : MonoBehaviour
{

    public GameObject rulePrefab;

    public void InitRuleList() {
        
        var rulesList = FindObjectOfType<RulesManager>().rules;

        foreach (var rule in rulesList) {
            var ruleObject = Instantiate(rulePrefab, transform);
            ruleObject.GetComponentInChildren<TextMeshProUGUI>().text = rule.Item1;
        }
    }
}
