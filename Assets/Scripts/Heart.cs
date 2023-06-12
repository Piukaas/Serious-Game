using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private SceneManager sceneManager;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Start")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
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
