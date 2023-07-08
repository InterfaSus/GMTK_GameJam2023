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
    public MailCategory currentCategory { get; private set; }

    List<Mail> mails;
    TextMeshProUGUI[] categoriesNumbers;

    void Start() {
        
        categoriesNumbers = categoriesContainer.GetComponentsInChildren<TextMeshProUGUI>().Where(x => x.name.Contains("Number")).ToArray();

        mails = new List<Mail>();

        mails.Add(new Mail("The Legend of Adventure", "John Doe", "Action", 4, "Embark on an epic quest to save the kingdom from evil forces.", true));
        mails.Add(new Mail("Space Odyssey", "Jane Smith", "Sci-Fi", 3, "Explore the vastness of space and uncover the secrets of distant galaxies.", true));
        mails.Add(new Mail("Fantasy Realms", "Mike Johnson", "RPG", 5, "Immerse yourself in a fantasy world filled with magic, dragons, and heroic quests.", true));
        mails.Add(new Mail("Battlefield Tactics", "Sarah Davis", "Strategy", 2, "Command your troops and outsmart your enemies in intense battlefield battles.", true));
        mails.Add(new Mail("Super Kart Racing", "Alex Thompson", "Racing", 4, "Experience high-speed racing action and compete against friends in thrilling kart races.", true));
        mails.Add(new Mail("Mystery Mansion", "Emily Wilson", "Adventure", 5, "Unravel the mysteries of an old mansion and solve challenging puzzles along the way.", true));
        mails.Add(new Mail("Ninja Warrior", "Ryan Garcia", "Platformer", 3, "Master the art of stealth and agility as you navigate treacherous obstacle courses.", true));
        mails.Add(new Mail("Virtual Reality Quest", "Lily Adams", "Simulation", 4, "Step into a virtual world and live out your wildest dreams through immersive gameplay.", true));
        mails.Add(new Mail("Sports Mania", "Chris Roberts", "Sports", 1, "Engage in intense sports competitions and strive to become the ultimate champion.", true));
        mails.Add(new Mail("Puzzle Master", "Sophia Lee", "Puzzle", 5, "Challenge your mind with mind-bending puzzles and test your problem-solving skills.", true));

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
    }

    public void UpdateCategoriesNumbers() {
            
        for (int i = 0; i < categoriesNumbers.Length; i++) {
            categoriesNumbers[i].text = mails.Where(x => (int)(x.Category) == i).Count().ToString();
        }
    }

    IEnumerator SendNewMail() {

        while (true) {

            yield return new WaitForSeconds(1.0f);

            var newMail = new Mail("New Mail", "New Author", "New Genre", Random.Range(1, 6), "New Description", false);
            mails.Add(newMail);

            UpdateCategoriesNumbers();
            UpdateDisplayList(currentCategory);
        }
    }
}
