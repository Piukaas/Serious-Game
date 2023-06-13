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

    public void MenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    public void DetailButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("DetailPage");
    }

    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Infopage");
    }

    public void GameButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
