using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour {

    public Text score;
    public Text highscore;
	public static int number;


    private void Start()
    {
        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        score.text = "0";
		number = 0;
     
    }
	public int get_number(){
		return number;
	}
				

    public void CalcScore()
    {
        number++;
        score.text = number.ToString();
		LevelGenerator.upgrade_weap = false;

        if (number > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", number);
            highscore.text = number.ToString();
        }
        
    }
}
