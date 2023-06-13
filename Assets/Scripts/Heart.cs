using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private SceneManager sceneManager;
    public Text titleText;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            titleText.text = "Het leven in handen       Floor";
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            titleText.text = "Het leven in handen       Mark";
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            titleText.text = "Het leven in handen       Emma";
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            titleText.text = "Het leven in handen       Finn";
        }
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Start")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Infopage");
        }
        else if (gameObject.tag == "Character")
        {
            sceneManager.InfoButton();
        }
        else if (gameObject.tag == "Story")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stories");
        }
    }
}
