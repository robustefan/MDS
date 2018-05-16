using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyMainMenu : MonoBehaviour {
    public static float gameTime;

	public void PlayGame()
    {
        gameTime = Time.time;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
