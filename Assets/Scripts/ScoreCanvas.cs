using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour {

    public GameObject p1E, p2E, p3E,p1R,p2R,p3R;
    float wait1 = 5F, wait2 = 10F, wait3 = 15F;

	void Update () {
        if (LanguageMenu.tutorial == true)
        {
            if (LanguageMenu.language == true)
            {
                p1E.SetActive(true);
                p2E.SetActive(false);
                p3E.SetActive(false);
                if (Time.time > MyMainMenu.gameTime + wait1)
                {
                    p1E.SetActive(false);
                    p2E.SetActive(true);
                }

                if (Time.time > MyMainMenu.gameTime + wait2)
                {
                    p1E.SetActive(false);
                    p2E.SetActive(false);
                    p3E.SetActive(true);
                }

                if (Time.time > MyMainMenu.gameTime + wait3)
                {
                    p1E.SetActive(false);
                    p2E.SetActive(false);
                    p3E.SetActive(false);
                }
            }
            else
            {
                p1E.SetActive(false);
                p2E.SetActive(false);
                p3E.SetActive(false);

                p1R.SetActive(true);
                p2R.SetActive(false);
                p3R.SetActive(false);
                if (Time.time > MyMainMenu.gameTime + wait1)
                {
                    p1R.SetActive(false);
                    p2R.SetActive(true);
                }

                if (Time.time > MyMainMenu.gameTime + wait2)
                {
                    p1R.SetActive(false);
                    p2R.SetActive(false);
                    p3R.SetActive(true);
                }

                if (Time.time > MyMainMenu.gameTime + wait3)
                {
                    p1R.SetActive(false);
                    p2R.SetActive(false);
                    p3R.SetActive(false);
                }
            }
        }

    }
	
}
