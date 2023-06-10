using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (gameObject.tag == "Start")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        }
        else if (gameObject.tag == "Character")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Characters");
        }
        else if (gameObject.tag == "Story")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stories");
        }
    }
}
