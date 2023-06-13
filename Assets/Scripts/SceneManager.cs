using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void CharactersButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Characters");
    }

    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    public void InfoButton()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Floor Infopage");
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mark Infopage");
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Emma Infopage");
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Finn Infopage");
        }
    }
}
