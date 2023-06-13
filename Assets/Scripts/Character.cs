using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private SceneManager sceneManager;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    public void OnMouseDown()
    {
        if (gameObject.tag == "Floor")
        {
            PlayerPrefs.SetString("Character", "Floor");
        }
        else if (gameObject.tag == "Mark")
        {
            PlayerPrefs.SetString("Character", "Mark");
        }
        else if (gameObject.tag == "Emma")
        {
            PlayerPrefs.SetString("Character", "Emma");
        }
        else if (gameObject.tag == "Finn")
        {
            PlayerPrefs.SetString("Character", "Finn");
        }
        sceneManager.MenuButton();
    }
}
