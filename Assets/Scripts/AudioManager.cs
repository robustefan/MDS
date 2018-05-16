using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour {

    public Slider volumeSlider1,volumeSlider2;
    public AudioSource audioMenu;

    private void Start()
    {
        volumeSlider1.value = PlayerPrefs.GetFloat("Volume", 1);
        volumeSlider2.value = PlayerPrefs.GetFloat("Volume", 1);
        audioMenu.volume = PlayerPrefs.GetFloat("Volume", 1);
    }
    void Update ()
    {
        audioMenu = GameObject.FindObjectOfType<AudioSource>();
        volumeSlider1.onValueChanged.AddListener(delegate { volumeSlider2.value = volumeSlider1.value; audioMenu.volume = volumeSlider1.value; PlayerPrefs.SetFloat("Volume", audioMenu.volume); });
        volumeSlider2.onValueChanged.AddListener(delegate { volumeSlider1.value = volumeSlider2.value; audioMenu.volume = volumeSlider2.value; PlayerPrefs.SetFloat("Volume", audioMenu.volume); });
	}

    public float getAudio()
    {
        return audioMenu.volume;
    }
}
