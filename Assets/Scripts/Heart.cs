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
        if (gameObject.tag == "Start")
        {
            sceneManager.StartButton();
        }
        else if (gameObject.tag == "Character")
        {
            sceneManager.DetailButton();
        }
    }
}
