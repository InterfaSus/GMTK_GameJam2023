using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

        authorText.text = "FROM: " + mail.Author;
        genreText.text = "GENRE: " + mail.Genre;
        ratingText.text = mail.Rating.ToString() + "/5";

        if (mail.Category == MailCategory.Correct || mail.Category == MailCategory.Incorrect) {
            acceptButton.gameObject.SetActive(false);
            rejectButton.gameObject.SetActive(false);
        }
    }

    public void Respond(bool accepted) {

        if (accepted == instanceMail.IsValid) {

            FindObjectOfType<ScoreManager>().UpdateScore(10);
            instanceMail.Category = MailCategory.Correct;
        }
        else {
            instanceMail.Category = MailCategory.Incorrect;
        }

        mailManager.UpdateCategoriesNumbers();
        mailManager.UpdateDisplayList(mailManager.currentCategory);
    }
}
