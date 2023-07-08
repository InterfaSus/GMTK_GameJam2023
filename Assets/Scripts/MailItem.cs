using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MailItem : MonoBehaviour
{
    
    public TextMeshProUGUI authorText;
    public TextMeshProUGUI genreText;
    public TextMeshProUGUI ratingText;
    public Button acceptButton;
    public Button rejectButton;

    Mail instanceMail;
    MailManager mailManager;

    void Start() {
            
        mailManager = FindObjectOfType<MailManager>();
    }

    public void InitMail(Mail mail) {

        instanceMail = mail;

        authorText.text = mail.From;
        genreText.text = "GENRE: " + mail.Genre;
        ratingText.text = mail.StoreRating.ToString() + "/5";

        if (mail.Category == MailCategory.Correct || mail.Category == MailCategory.Incorrect) {
            acceptButton.gameObject.SetActive(false);
            rejectButton.gameObject.SetActive(false);
        }
    }

    public void Respond(bool accepted) {

        mailManager.Respond(instanceMail, accepted);
    }

    public void ShowMailInfo() {

        var fullMailObject = mailManager.fullMailObject;
        
        fullMailObject.gameObject.SetActive(true);
        fullMailObject.GetComponent<FullMailObject>().InitFullMail(instanceMail);
    }
}
