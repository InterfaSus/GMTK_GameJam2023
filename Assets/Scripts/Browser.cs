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

    public void FocusTab(string name) {

        pages.ForEach(p => p.gameObject.SetActive(p.pageName == name));
    }
}
