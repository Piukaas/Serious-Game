using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Text titleText;
    public Text explanationText;

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            titleText.text = "Floor krijgt een hartaanval!";
            explanationText.text = "Als gevolg van de keuzes heeft Floor een hartaanval gekregen. \n \n Waardoor jij nu de taak hebt om haar te reanimeren en haar leven te redden.";
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            titleText.text = "Mark krijgt een hartaanval!";
            explanationText.text = "Als gevolg van de keuzes heeft Mark een hartaanval gekregen. \n \n Waardoor jij nu de taak hebt om hem te reanimeren en zijn leven te redden.";
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            titleText.text = "Emma krijgt een hartaanval!";
            explanationText.text = "Als gevolg van de keuzes heeft Emma een hartaanval gekregen. \n \n Waardoor jij nu de taak hebt om haar te reanimeren en haar leven te redden.";
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            titleText.text = "Finn krijgt een hartaanval!";
            explanationText.text = "Als gevolg van de keuzes heeft Finn een hartaanval gekregen. \n \n Waardoor jij nu de taak hebt om hem te reanimeren en zijn leven te redden.";
        }
    }
}
