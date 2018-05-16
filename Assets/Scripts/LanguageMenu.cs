using UnityEngine;
using UnityEngine.UI;


public class LanguageMenu : MonoBehaviour {

    public static bool language = true, tutorial=true ;
    public Button Romana, Engleza;
    public Toggle Sunet, Tutorial;

    void Awake()
    {
        Button btnR = Romana.GetComponent<Button>();
        Button btnE = Engleza.GetComponent<Button>();
        btnR.onClick.AddListener(delegate { language=false; Debug.Log("Limba romana"); }); 
        btnE.onClick.AddListener(delegate { language=true; Debug.Log("Limba engleza"); }); 
    }

    private void Update()
    {
        if (Tutorial.isOn == false)
        {
            tutorial = false;
        }
        else
        {
            tutorial = true;
        }
    }
}
