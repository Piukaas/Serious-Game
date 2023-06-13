using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Text titleText;

    private void Awake()
    {
        var character = PlayerPrefs.GetString("Character");
        titleText.text = "Het leven in handen\n" + character;
    }
}
