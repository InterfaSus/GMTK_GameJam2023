using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TutorialManager : MonoBehaviour
{

    public GameObject tutorialPanel;
    public List<string> tutorialTexts; // Lista de texto asociado a cada índice
    public TextMeshProUGUI tutorialText; // Objeto de texto en la escena para mostrar el texto

    [Serializable]
    public struct Objects
    {
            public List<GameObject> ObjectsOnStep_0;
            public List<GameObject> ObjectsOnStep_1;
            public List<GameObject> ObjectsOnStep_2;
            public List<GameObject> ObjectsOnStep_3;
            public List<GameObject> ObjectsOnStep_4;
            public List<GameObject> ObjectsOnStep_5;
            public List<GameObject> ObjectsOnStep_6;
            public List<GameObject> ObjectsOnStep_7;
            public List<GameObject> ObjectsOnStep_8;
            public List<GameObject> ObjectsOnStep_9;
            public List<GameObject> ObjectsOnStep_10;
            public List<GameObject> ObjectsOnStep_11;
            public List<GameObject> ObjectsOnStep_12; 
            public List<GameObject> ObjectsOnStep_13; 
            public List<GameObject> ObjectsOnStep_14; 
            public List<GameObject> ObjectsOnStep_15; 
            public List<GameObject> ObjectsOnStep_16; 
            public List<GameObject> ObjectsOnStep_17; 
            public List<GameObject> ObjectsOnStep_18; 
            public List<GameObject> ObjectsOnStep_19; 
            public List<GameObject> ObjectsOnStep_20; 
            public List<GameObject> ObjectsOnStep_21; 
    }
    public Objects list = new Objects();

    private List<List<GameObject>> tutorialObjects; // Lista de objetos asociados en el tutorial


    void Start()
    {
        Debug.Log(list.ObjectsOnStep_0[0].name);

        tutorialObjects = new List<List<GameObject>>();
        if (Persistents.DidTutorial) {
            tutorialPanel.SetActive(false);
            return;
        }

        AddTexts();
        AddObjects();
        
        // Desactiva todos los objetos asociados, excepto el primero
        for (int i = 1; i < tutorialObjects.Count; i++) {
            
            foreach (var tutObject in tutorialObjects[i])
            {
                tutObject.SetActive(false);
            }
        }

        // Activa el objeto asociado al primer índice
        foreach (var tutObject in tutorialObjects[0])
        {
            tutObject.SetActive(true);
        }
        
        tutorialText.text = tutorialTexts[0];
    }

    private void AddObjects()
    {
        tutorialObjects.Add(list.ObjectsOnStep_0);
        tutorialObjects.Add(list.ObjectsOnStep_1);
        tutorialObjects.Add(list.ObjectsOnStep_2);
        tutorialObjects.Add(list.ObjectsOnStep_3);
        tutorialObjects.Add(list.ObjectsOnStep_4);
        tutorialObjects.Add(list.ObjectsOnStep_5);
        tutorialObjects.Add(list.ObjectsOnStep_6);
        tutorialObjects.Add(list.ObjectsOnStep_7);
        tutorialObjects.Add(list.ObjectsOnStep_8);
        tutorialObjects.Add(list.ObjectsOnStep_9);
        tutorialObjects.Add(list.ObjectsOnStep_10);
        tutorialObjects.Add(list.ObjectsOnStep_11);
        tutorialObjects.Add(list.ObjectsOnStep_12);
        tutorialObjects.Add(list.ObjectsOnStep_13);
        tutorialObjects.Add(list.ObjectsOnStep_14);
        tutorialObjects.Add(list.ObjectsOnStep_15);
        tutorialObjects.Add(list.ObjectsOnStep_16);
        tutorialObjects.Add(list.ObjectsOnStep_17);
        tutorialObjects.Add(list.ObjectsOnStep_18);
        tutorialObjects.Add(list.ObjectsOnStep_19);
        tutorialObjects.Add(list.ObjectsOnStep_20);
        tutorialObjects.Add(list.ObjectsOnStep_21);

    }

    private void AddTexts()
    {
        tutorialTexts.Add("Hello hello! Are you the new unpaind intern? For now you have no way of texting me back so I don't know if you are there.");
        tutorialTexts.Add("OH!! Did you click on my message? Or is this just another weird bug?");
        tutorialTexts.Add("THERE IT IS AGAIN!!!, Alright if you are there and you're sentient click on the Mails window, here I'll put a big fat arrow there.");
        tutorialTexts.Add("Oh so you are the intern, or at least you're pretending to, that's enough for me not gonna lie.");
        tutorialTexts.Add("Your work here it's really simple, our AI isn't strong enough yet so you'll have to filter the submissions manually. There are a ton of rules to follow, but don't worry about that now, first let me show you how this Mail thing works.");
        tutorialTexts.Add("This are the categories: INBOX; CORRECT; INCORRECT & SPAM. Our bot it's good enough to tell you if you're wrong but not good enough to decide by itself if something it's wrong, isn't that kinda useless?");
        tutorialTexts.Add("But well I've heard that people in IT are not being paid enough... ANYWAY, let me send you a bunch of random mails to test things out.");
        tutorialTexts.Add("A lot of people submit to this Jam, so here you can see the most relevant details, like who sent the submission, the genre, and the star rating");
        tutorialTexts.Add("I don't recommend to accept submissions directly from here, but you'll usually see a REALLY bad submission, like this one, and you can deny it directly. Give it a try, press the X button.");
        tutorialTexts.Add("I said deny. Are you really the new intern?. If you dont get to the minimum score by the end of the day you're fired, and for each mistake they will substract points from your score. Well I really don't care, just press the OK button");
        tutorialTexts.Add("Perfect! it's as simple as that. Do you see that big flashy SCORE icon? From each correct answer you'll get some points, if you don't get to the minimum by the end of day you're fired.");
        tutorialTexts.Add("Now click one of the mails to see the expanded detail.");
        tutorialTexts.Add("Here you can see everything about the submission");
        tutorialTexts.Add("There's the full mail, the critics, the description. Be careful with the spam, if you deny it it won't give you points, but it'll deduct points from your score.");
        tutorialTexts.Add("That's all from the Mail window. Now it's time to take you to that rusty old server. Click here");
        tutorialTexts.Add("As you can read the Rule Server is really slow, so you'll waste your precious time if you just keep checking out the Rules again and again, so make sure to just get here when you REALLY need it.");
        tutorialTexts.Add("Click Proceed to open it up");
        tutorialTexts.Add("You can even hear the fans, I don't know why they haven't improve it yet");
        tutorialTexts.Add("Here we are this are the Rules, this will change everyday so make sure to check them out at the beginning of each day. Make sure that you ONLY accept submissions under the correct Rules");
        tutorialTexts.Add("This can be a lot so if you check this square you will be able to remember a few rules for a while pressing the Right Click");
        tutorialTexts.Add("You're not one of those bots, so your memory will get dizzy eventually, you know how things are nowadays. But a quick glance at the rules will set your memories in place.");
        tutorialTexts.Add("Today is just Training Day so you don't need to worry about the time, but as soon as tomorrow you'll be working here from 7:30 AM to 4:00 PM, make sure to meet your goal before you go. See you soon ;)");
        
    }

    public bool incorrectOption = true;

    int index = 0;
    public void GoToNext()
    {
        if(index == 8)
            if (incorrectOption) index = 9;
            else index = 10;

        else index++;

        SetText(index);
        SetObjectsActive(index);
    }

    private void SetObjectsActive(int index)
    {
        foreach (var tutObject in tutorialObjects[index])
        {
            tutObject.SetActive(true);
        }

        for (int i = 0; i < tutorialObjects.Count; i++)
        {
            if(i == index) 
            {
                continue;
            }

            foreach (var tutObject in tutorialObjects[i])
            {
                tutObject.SetActive(false);
            }
        }
    }

    float timeBetweenLetters = 1.0f;
    int currentChar = 0;
    private void SetText(int index)
    {
        tutorialText.text = "";
        currentChar = 0;
        WriteText();
    }

    private string WriteText()
    {
        string v = tutorialTexts[index];
        
        if (currentChar < v.Length)
        {
            tutorialText.text += v[(int)currentChar];
            currentChar++;
            Invoke("WriteText", timeBetweenLetters);
        }
        return tutorialText.text;
    }
}

