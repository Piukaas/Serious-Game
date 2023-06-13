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
        PlayerPrefs.SetString("Character", gameObject.tag);
        sceneManager.MenuButton();
    }
}
