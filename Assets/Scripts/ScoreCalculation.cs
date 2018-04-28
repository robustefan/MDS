using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour {

    public Text score;
    public Text highscore;
    public GameObject player;
    int number = 0;
    

    private void Start()
    {
        

        highscore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        score.text = "0";
     
    }

    private void Update()
    {
        bool tasta = Input.GetKeyDown(KeyCode.UpArrow);
        if (tasta)
        {
            CalcScore();
        }
    }
    public void CalcScore()
    {
        number++;
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", number);
            highscore.text = number.ToString();
        }
        
    }
}
