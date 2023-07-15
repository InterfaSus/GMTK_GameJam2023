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
    public Button nextButton;

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
            public List<GameObject> ObjectsOnStep_22; 
    }
    public Objects list = new Objects();

    private List<List<GameObject>> tutorialObjects; // Lista de objetos asociados en el tutorial
    private static Dictionary<string, float> times = new Dictionary<string, float>() {
        { "[L]", 0.0f },
        { "[S]", 0.0f },
    };
    private float defaultTime = 0.0f;
    void Start()
    {
        if(!Persistents.DidTutorial)
        {
            tutorialObjects = new List<List<GameObject>>();
            

            if (Persistents.DidTutorial) {
                tutorialPanel.SetActive(false);
                return;
            }

            AddTexts();
            AddObjects();
            
            GoToNext();
        }
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
        tutorialObjects.Add(list.ObjectsOnStep_22);
    }

    private void AddTexts()
    {
        tutorialTexts.Add("Hello hello![S] Are you the new unpaind intern?[L] For now you have no way of texting me back so I don't know if you are there.");
        tutorialTexts.Add("OH!![L] Did you click on my message?[S] Or is this just another weird bug?");
        tutorialTexts.Add("THERE IT IS AGAIN!!![L], Alright if you are there and you're sentient[S] click on the Mails window,[L] here I'll put a big fat arrow there.{E}");
        tutorialTexts.Add("Oh so you ARE the intern,[S] or at least you're pretending to,[S] that's enough for me not gonna lie.");
        tutorialTexts.Add("Your work here it's really simple,[S] our AI isn't strong enough yet[S] so you'll have to filter the submissions manually.[L] There are a ton of rules to follow,[S] but don't worry about that now,[S] first let me show you how this Mail thing works.");
        tutorialTexts.Add("This are the categories: INBOX{E},[L][L] CORRECT{E},[L][L] INCORRECT{E}[L][L] and SPAM.{E}[L][L] Our bot it's good enough to tell you if you're wrong but not good enough to decide by itself if something it's wrong,[S] isn't that kinda useless?");
        tutorialTexts.Add("But well I've heard that people in IT are not being paid enough...[L] ANYWAY,[S] let me send you a bunch of random mails to test things out.");
        tutorialTexts.Add("A lot of people submit to this Jam,[S] so here you can see the most relevant details,[S] like who sent the submission,[S] the genre,[S] and the star rating.");
        tutorialTexts.Add("I don't recommend to accept submissions directly from here,[S] but you'll usually see a REALLY bad submission,[S] like this one{E},[S] and you can deny it directly.[L] Give it a try,[S]{E} press the X button.");
        tutorialTexts.Add("I said deny.[L] Are you really the new intern?.[L] If you dont get to the minimum score by the end of the day you're fired,[S] and for each mistake they will substract points from your score.[L] Well I really don't care,[S] just press the OK button.");
        tutorialTexts.Add("Perfect![L] Do you see that big flashy SCORE icon? Today you won't cause you're just following instructions but from each correct answer you'll get some points,[S] make sure to met the goal.[L] You can spend those points later, try to gain as much as you can.");
        tutorialTexts.Add("Now,[L] click one of the mails to see the expanded detail.");
        tutorialTexts.Add("Here you can see everything about the submission.");
        tutorialTexts.Add("There's the full mail,[S] the critics,[S] the description.[L] Be careful with the spam,[S] if you deny it it won't give you points,[S] but it'll deduct points from your score.");
        tutorialTexts.Add("That's all from the Mail window.[L] Now it's time to take you to that rusty old server.[L] Click here. {E}");
        tutorialTexts.Add("As you can read the Rule Server is really slow,[S] so you'll waste your precious time if you just keep checking out the Rules again and again,[S] so make sure to just get here when you REALLY need it.");
        tutorialTexts.Add("Click YES to open it up");
        tutorialTexts.Add("Today there are no rules and even like that it is stuck. Let me brute force this.");
        tutorialTexts.Add("Here![L] In a normal day, here will appear the rules.But I can't send you the rules just like I sent you the mails tho, that's on CEO territory. There can be a lot of rules, some are easier to remember than others.");
        tutorialTexts.Add("This can be a lot so if you choose any rule you will be able to remember it with our System Expansion for a while pressing the Right Click. Today there's nothing to remember so I'll make a memo,[L]{E} there it is.");
        tutorialTexts.Add("You're not one of those bots,[S] so your memory will get dizzy eventually,[S] you know how things are nowadays.[L] But a quick glance at the rules will set your memories in place.");
        tutorialTexts.Add("Today is just Training Day so you don't need to worry about the time,[S] but tomorrow you'll be working here from 7:30 AM to 4:00 PM,[S] make sure to meet your goal before you go.");
        tutorialTexts.Add("That's really all I need to teach you really,[S] you only need to work 5 days after all.[L][L] See you soon ;).");
        
    }

    public bool incorrectOption = true;

    int myindex = -1;
    public void GoToNext()
    {
        if(myindex < 22)
        {
            if(myindex != 2 && myindex != 8 && myindex != 11 && myindex != 14 && myindex != 16)
            ToggleButton();

            if(myindex == 8)
                if (incorrectOption) myindex = 9;
                else myindex = 10;
            else if(myindex == 9) myindex = 11;
            else myindex++;
        }
        else
        {
            Persistents.DidTutorial = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        SetText(myindex);
        SetObjectsActive(myindex);
    }

    private void ToggleButton()
    {
        nextButton.interactable = !nextButton.interactable;
    }

    private void SetObjectsActive(int myindex)
    {

        foreach (var tutObject in tutorialObjects[myindex])
        {
            tutObject.SetActive(true);
        }

        for (int i = 0; i < tutorialObjects.Count; i++)
        {
            if(i == myindex) 
            {
                continue;
            }
            
            foreach (var tutObject in tutorialObjects[i])
            {
                tutObject.SetActive(false);
            }
        }
    }

    int currentChar = 0;
    private void SetText(int myindex)
    {
        tutorialText.text = "";
        currentChar = 0;
        ProcessText();
    }

    private void ProcessText()
    {
        string v = tutorialTexts[myindex];
        float timeBetweenLetters = defaultTime;
        

        if (currentChar < v.Length)
        {
            
            if(v[currentChar] == '[')
            {
                char[] array = {v[currentChar],v[currentChar+1],v[currentChar+2]};
                string keyWord = new string(array);

                if(times.ContainsKey(keyWord))
                timeBetweenLetters = times[keyWord];

                currentChar = currentChar+3;
            }
            else if(v[currentChar] == '{')
            {
                CallNextEvent();
                currentChar = currentChar+3;
            }
            else WriteChar(v);

            Invoke("ProcessText", timeBetweenLetters);
        }

        else if(currentChar == v.Length) 
        {   
            if(myindex != 2 && myindex != 8 && myindex != 11 && myindex != 14 && myindex != 16)
            ToggleButton();
        }
    }
    private void WriteChar(string v)
    {
        tutorialText.text += v[currentChar];

        currentChar++;
    }


    int eventCounter = 1;

    public GameObject EventOneArrow;
    public GameObject EventOneBlock;

    public GameObject EventTwoArrow;
    public GameObject EventThreeArrow;
    public GameObject EventFourArrow;
    public GameObject EventFiveArrow;

    public GameObject EventSixArrow;

    public Button EventSevenButton1;
    public Button EventSevenButton2;

    public GameObject EventEightArrow;
    public GameObject EventNineBlockNote;


    private void CallNextEvent()
    {
        Debug.Log("Event #" + eventCounter);
        switch(eventCounter)
        {
            case 1:
                EventOneArrow.SetActive(true);
                EventOneBlock.SetActive(false);
                break;
            case 2:
                EventTwoArrow.SetActive(true);
                break;
            case 3:
                EventTwoArrow.SetActive(false);
                EventThreeArrow.SetActive(true);
                break;
                //Algo;
            case 4:
                EventThreeArrow.SetActive(false);
                EventFourArrow.SetActive(true);
                break;
                //Algo;
            case 5:
                EventFourArrow.SetActive(false);
                EventFiveArrow.SetActive(true);
                break;
                //Algo;
            case 6:
                EventSixArrow.SetActive(true);
                break;
            case 7:
                EventSevenButton1.interactable = true;
                EventSevenButton2.interactable = true;
                break;
            case 8:
                EventEightArrow.SetActive(true);
                break;
            case 9:
                EventNineBlockNote.SetActive(false);
                break;
        }

        eventCounter++;
    }

    public void ChoosePath(bool incorrectAnswer) => incorrectOption = incorrectAnswer;

}

