using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
	public Toggle tutorialButton;

	public void Awake()
	{
		PlayerPrefs.SetInt ("Hide", 0);
		ToggleTutorial ();
	}

	public void Update()
	{
		if (PlayerPrefs.GetInt("Hide", 0) == 0)
		{
			tutorialButton.graphic.CrossFadeAlpha(1, 0, false);
		}
		else
		{
			tutorialButton.graphic.CrossFadeAlpha(0, 0, false);
			// Toggle off.
		}
	}

	public void ToggleTutorial()
	{
		if (PlayerPrefs.GetInt("Hide", 0) == 0)
		{
			PlayerPrefs.SetInt("Hide", 1);
			LanguageMenu.tutorial = true;
			tutorialButton.graphic.CrossFadeAlpha(1, 0, false);
		}
		else
		{
			PlayerPrefs.SetInt("Hide", 0);
			LanguageMenu.tutorial = false;
			tutorialButton.graphic.CrossFadeAlpha(0, 0, false);
		}
	}
}
