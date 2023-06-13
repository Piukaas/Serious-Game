using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text titleText;

    private void Awake()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            titleText.text = "Het leven in handen \n Floor";
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            titleText.text = "Het leven in handen \n Mark";
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            titleText.text = "Het leven in handen \n Emma";
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            titleText.text = "Het leven in handen \n Finn";
        }
    }
}
