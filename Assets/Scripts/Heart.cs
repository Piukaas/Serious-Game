using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private SceneManager sceneManager;

    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    public void OnMouseDown()
    {
        if (gameObject.CompareTag("Start"))
        {
            sceneManager.StartButton();
        }
        else if (gameObject.CompareTag("Character"))
        {
            sceneManager.DetailButton();
        }
    }
}
