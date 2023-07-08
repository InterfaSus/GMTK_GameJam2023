using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{

    RulesManager rulesManager;

    void Start() {

        rulesManager = GetComponent<RulesManager>();
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.RightAlt)) {
            
            int valid = 0;
            int total = 1000;
            for (int i = 0; i < total; i++) {

                var mail = Mail.GenerateMail();
                if (rulesManager.CheckRules(mail)) {
                    valid++;
                }
            }

            Debug.Log($"Valid: {valid} / {total}");
        }
    }
}
