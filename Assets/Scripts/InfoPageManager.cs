using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoPageManager : MonoBehaviour
{
    public void StartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
