using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeButton : MonoBehaviour
{
    
    MailManager mailManager;

    void Start() {

        mailManager = FindObjectOfType<MailManager>();
    }
}
