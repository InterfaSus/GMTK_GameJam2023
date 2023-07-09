using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialManager : MonoBehaviour
{

    public GameObject tutorialPanel;
    public List<GameObject> tutorialObjects; // Lista de objetos asociados en el tutorial
    public List<string> tutorialTexts; // Lista de texto asociado a cada índice
    public TextMeshProUGUI tutorialText; // Objeto de texto en la escena para mostrar el texto
    private int currentIndex = 0; // Índice actual

    void Start()
    {

        if (Persistents.DidTutorial) {
            tutorialPanel.SetActive(false);
        }

        // Agrega los primeros 3 elementos a la lista de texto
        tutorialTexts.Add("Hello hello! Down here, I'll guide you through the process of filtering the submissions of the Jam.");
        tutorialTexts.Add("Click here! This is the Mails Window, all mails are gonna appear there, and that's your work. If you do a good work all mails are going to be send to the Correct. Tab. If you manage to reach your goald dont stop! You can buy upgrades with those points ;)");
        tutorialTexts.Add("As you can see there are categories, it's your work to filter the submissions and gain points. Theres also A LOT of Spam, spam wont give you points, but it will drain your score if you accept Spam, so be careful");
        tutorialTexts.Add("A lot of people submit to this Jam, so here you can see the most relevant details, but I do not recommend to approve or dissapprove a mail without further inspection, so Click it, but HEY!, I'm not going to tell you how to do your work.");
        tutorialTexts.Add("HERE! Here are the expanded details and BIG JUICY BUTTONs, c'mon PUSH IT");
        tutorialTexts.Add("Sorry I got carry away, here are the expanded details, make sure all its good with this submission, and if it is just Push the BIG- green button.");
        tutorialTexts.Add("Click here, now Im going to take you to that rusty old server.");
        tutorialTexts.Add("As you can read the Rule Server is really slow, so you'll waste your precious time if you just keep checking out the Rules again and again, so make sure to just get here when you REALLY need it.");
        tutorialTexts.Add("This are the Rules, this will change everyday so make sure to check them out at the beginning of each day. Make sure that you ONLY accept submissions under the correct Rules, this can be a lot so if you check this square you will be able to remember a few rules for a while pressing the Right Click");
        tutorialTexts.Add("Today is just Training Day so you don't need to worry about the time, but as soon as tomorrow you'll be working here from 7:30 AM to 4:00 PM, make sure to meet your goal before you go or you'll get fire. See you soon ;)");
        


        // Desactiva todos los objetos asociados, excepto el primero
        for (int i = 1; i < tutorialObjects.Count; i++) {
            tutorialObjects[i].SetActive(false);
        }

        // Activa el objeto asociado al primer índice
        tutorialObjects[0].SetActive(true);
        tutorialText.text = tutorialTexts[0];
    }

    public void GoToNext()
    {
        if(currentIndex == 9)
        {
            Persistents.DidTutorial = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


            // Desactiva el objeto asociado actual
            tutorialObjects[currentIndex].SetActive(false);

            // Incrementa el índice actual, asegurándose de que no supere el máximo
            currentIndex++;
            if (currentIndex >= tutorialObjects.Count) {
                currentIndex = tutorialObjects.Count - 1;
            }

            // Activa el objeto asociado al nuevo índice actual y muestra el texto correspondiente
            tutorialObjects[currentIndex].SetActive(true);
            tutorialText.text = tutorialTexts[currentIndex];
        
    }

    public void GoToNextOnSubs()
    {
        if (currentIndex == 1) 
        {
            GoToNext();
        }
    }

    public void GoToNextOnWarning()
    {
        if (currentIndex == 7) GoToNext();
    }

    public void GoToNextOnBigMail()
    {
        if (currentIndex == 4) GoToNext();
    }

    public void GoToNextOnRules()
    {
        if (currentIndex == 6) GoToNext();
    }

    
}

