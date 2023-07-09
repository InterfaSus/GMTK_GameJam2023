using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FullMailObject : MonoBehaviour {

    public GameObject buttons;
    public TextMeshProUGUI fromText;
    public TextMeshProUGUI genreText;
    public TextMeshProUGUI[] ratingsText;
    public TextMeshProUGUI subgenresText;
    public TextMeshProUGUI starRating;
    public TextMeshProUGUI description;

    MailManager mailManager;
    Mail mail;

    void Start() {

        mailManager = FindObjectOfType<MailManager>();
    }

    public void InitFullMail(Mail mail) {

        this.mail = mail;
        if (mail.Category == MailCategory.Correct || mail.Category == MailCategory.Incorrect) {
            buttons.SetActive(false);
        }

        fromText.text = mail.From;
        genreText.text = "Genre: " + mail.Genre;
        starRating.text = mail.StoreRating.ToString() + "/5";

        int i = 0;
        foreach (var item in mail.Ratings) {
            
            ratingsText[i].text = item.Key + ": " + item.Value.Item1 + "/" + item.Value.Item2 + "\n";
            i++;
        }

        subgenresText.text = string.Join(", ", mail.Subgenres);
        description.text = mail.Description;
    }

    public void Respond(bool accepted) {

        mailManager.Respond(mail, accepted);
        gameObject.SetActive(false);
    }
}
