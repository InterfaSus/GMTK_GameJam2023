using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Browser : MonoBehaviour
{
    public static Browser instance;

    public List<Page> pages;
    public GameObject[] blockers;
    private bool[] ActiveCurrently;


    void Awake()
    {
        instance = this;
    }

    void Start() {

        pages = new List<Page>(GetComponentsInChildren<Page>(includeInactive: true));
        
        pages.ForEach(p => p.gameObject.SetActive(false));
        pages[0].gameObject.SetActive(false);

        ActiveCurrently = new bool[pages.Count()]; 
    }

    public void FocusTab(string name) {

        int index = pages.FindIndex(p => p.pageName == name);

        //Si no esta desactiva la pagina, activala
        if (!ActiveCurrently[index]) {
            pages[index].gameObject.SetActive(true);
            ActiveCurrently[index] = true;
        }

        //Si esta activa, desactivala
        else {
            pages[index].gameObject.SetActive(false);
            ActiveCurrently[index] = false;
        } 
    }

    public void toggleBlocks()
    {
        foreach (GameObject blocker in blockers)
        {
            blocker.SetActive(!blocker.activeSelf);
        }
    }
}
