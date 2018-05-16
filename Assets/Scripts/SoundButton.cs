using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour {

    private Audio audio;
    public Toggle sound;
    
	void Start () {
        audio=GameObject.FindObjectOfType<Audio>();
        UpdateIcon();
	}

    private void Update()
    {
        UpdateIcon();
    }

    public void PauseMusic () {
        audio.ToggleSound();
        UpdateIcon();
	}

    private void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = PlayerPrefs.GetFloat("Volume",1);
            sound.graphic.CrossFadeAlpha(1,0,false);
        }
        else
        {
            AudioListener.volume = 0;
            sound.graphic.CrossFadeAlpha(0,0,false);
        }
    }
}
