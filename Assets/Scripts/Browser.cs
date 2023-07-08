using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Browser : MonoBehaviour
{
    
    public List<Page> pages;

    void Start() {

        pages = new List<Page>(GetComponentsInChildren<Page>(includeInactive: true));
        
        pages.ForEach(p => p.gameObject.SetActive(false));
        pages[0].gameObject.SetActive(true);
    }

    private bool ActiveCurrently = false; 

    public void FocusTab(string name) {

        if (!ActiveCurrently) {
            pages.ForEach(p => p.gameObject.SetActive(p.pageName == name));
            ActiveCurrently = true;
            Debug.Log("Activo");
        }

        else {
            foreach (var p in pages)
            {
                if (p.pageName == name) p.gameObject.SetActive(false);
            }
            ActiveCurrently = false;

            Debug.Log("Desactivo");
        } 

    }
}
