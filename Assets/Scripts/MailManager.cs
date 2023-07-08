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

    List<Mail> mails;
    TextMeshProUGUI[] categoriesNumbers;


    void Start() {

        fullMailObject.SetActive(false);
        categoriesNumbers = categoriesContainer.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.name.Contains("Number")).ToArray();

        mails = new List<Mail>();

        mails.Add(new Mail("The Legend of Adventure", "John Doe", "Action", new string[]{"Game", "Indie", "Fun"}, 4, "Embark on an epic quest to save the kingdom from evil forces.", true));
        mails.Add(new Mail("Space Odyssey", "Jane Smith", "Sci-Fi", new string[]{"Game", "Indie", "Fun"}, 3, "Explore the vastness of space and uncover the secrets of distant galaxies.", true));
        mails.Add(new Mail("Fantasy Realms", "Mike Johnson", "RPG", new string[]{"Game", "Indie", "Fun"}, 5, "Immerse yourself in a fantasy world filled with magic, dragons, and heroic quests.", true));
        mails.Add(new Mail("Battlefield Tactics", "Sarah Davis", "Strategy", new string[]{"Game", "Indie", "Fun"}, 2, "Command your troops and outsmart your enemies in intense battlefield battles.", true));
        mails.Add(new Mail("Super Kart Racing", "Alex Thompson", "Racing", new string[]{"Game", "Indie", "Fun"}, 4, "Experience high-speed racing action and compete against friends in thrilling kart races.", true));
        mails.Add(new Mail("Mystery Mansion", "Emily Wilson", "Adventure", new string[]{"Game", "Indie", "Fun"}, 5, "Unravel the mysteries of an old mansion and solve challenging puzzles along the way.", true));
        mails.Add(new Mail("Ninja Warrior", "Ryan Garcia", "Platformer", new string[]{"Game", "Indie", "Fun"}, 3, "Master the art of stealth and agility as you navigate treacherous obstacle courses.", true));
        mails.Add(new Mail("Virtual Reality Quest", "Lily Adams", "Simulation", new string[]{"Game", "Indie", "Fun"}, 4, "Step into a virtual world and live out your wildest dreams through immersive gameplay.", true));
        mails.Add(new Mail("Sports Mania", "Chris Roberts", "Sports", new string[]{"Game", "Indie", "Fun"}, 1, "Engage in intense sports competitions and strive to become the ultimate champion.", true));
        mails.Add(new Mail("Puzzle Master", "Sophia Lee", "Puzzle", new string[]{"Game", "Indie", "Fun"}, 5, "Challenge your mind with mind-bending puzzles and test your problem-solving skills.", true));

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

        if (accepted == mail.IsValid) {

            GetComponent<ScoreManager>().UpdateScore(10);
            mail.Category = MailCategory.Correct;
        }
        else {
            Browser.instance.FocusTab("error");
            Browser.instance.toggleBlocks();
            mail.Category = MailCategory.Incorrect;
        }

        UpdateCategoriesNumbers();
        UpdateDisplayList(currentCategory);
    }

    IEnumerator SendNewMail() {

        while (true) {

            yield return new WaitForSeconds(1.0f);

            var newMail = new Mail("New Mail", "New Author", "New Genre", new string[] {"Shooter"}, Random.Range(1, 6), "New Description", false);
            mails.Add(newMail);

            UpdateCategoriesNumbers();
            UpdateDisplayList(currentCategory);
        }
    }
}
