using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class MailManager : MonoBehaviour
{

    public GameObject mailPrefab;
    public GameObject mailsContainer;
    public GameObject categoriesContainer;
    public GameObject fullMailObject;
    public MailCategory currentCategory { get; private set; }

    public int correctScore = 10;
    public int incorrectScore = -3;

    List<Mail> mails;
    TextMeshProUGUI[] categoriesNumbers;


    void Start() {

        fullMailObject.SetActive(false);
        categoriesNumbers = categoriesContainer.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.name.Contains("Number")).ToArray();

        mails = new List<Mail>();

        UpdateCategoriesNumbers();
        UpdateDisplayList(MailCategory.Inbox);

        StartCoroutine(SendNewMail());
    }

    public void UpdateDisplayList(MailCategory category) {

        currentCategory = category;
        foreach (Transform child in mailsContainer.transform) {
            
            Destroy(child.gameObject);
        }

        foreach (var mail in mails) {
            
            if (mail.Category == category) {
                
                var mailObject = Instantiate(mailPrefab, mailsContainer.transform);
                mailObject.GetComponent<MailItem>().InitMail(mail);
            }
        }
    }

    public void ForButtonUpdateDisplayList(int index) {

        UpdateDisplayList((MailCategory)index);
        ButtonManager.instance.SetActiveCategoryButton(index);
    }

    public void UpdateCategoriesNumbers() {
            
        for (int i = 0; i < categoriesNumbers.Length; i++) {
            categoriesNumbers[i].text = mails.Where(x => (int)(x.Category) == i).Count().ToString();
        }
    }

    public void Respond(Mail mail, bool accepted) {
        
        mail.IsValid = GetComponent<RulesManager>().CheckRules(mail);

        if (accepted == mail.IsValid) {

            GetComponent<ScoreManager>().UpdateScore(correctScore * (mail.IsSpam ? 0 : 1));
            mail.Category = MailCategory.Correct;
        }
        else {

            GetComponent<ScoreManager>().UpdateScore(incorrectScore);

            Browser.instance.FocusTab("error");
            Browser.instance.toggleBlocks();

            mail.Category = MailCategory.Incorrect;
        }

        if (mail.IsSpam) {
            mail.Category = MailCategory.Spam;
        }

        UpdateCategoriesNumbers();
        UpdateDisplayList(currentCategory);
    }

    IEnumerator SendNewMail() {

        while (true) {

            yield return new WaitForSeconds(1.0f);

            var newMail = Mail.GenerateMail();

            bool filtered = Random.Range(0, 101) <= Persistents.upgradeLevels[2] * 25;
            if (newMail.IsSpam && filtered) newMail.Category = MailCategory.Spam;

            mails.Add(newMail);

            UpdateCategoriesNumbers();
            UpdateDisplayList(currentCategory);
        }
    }
}
