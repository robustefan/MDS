using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCanvas : MonoBehaviour {

    public GameObject MeniuEngleza, MeniuRomana;

    void Start () {
		if(LanguageMenu.language==false)
        {
            MeniuEngleza.SetActive(false);
            MeniuRomana.SetActive(true);
        }
        else
        {
            MeniuEngleza.SetActive(true);
            MeniuRomana.SetActive(false);
        }
	}
	
	// Update is called once per frame.
	void Update () {
		
	}
}
