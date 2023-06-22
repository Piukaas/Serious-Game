using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    public GameObject hintPanel;
    public Text timerDisplay;
    private float timer = 10f;
    private int score;

    private void Start()
    {
        PlayerPrefs.SetString("FinishedMaze", "Yes");
        score = PlayerPrefs.GetInt("Score");
        if (score > 50 && score < 60)
        {
            timer += 2f;
        }
        else if (score >= 60 && score < 70)
        {
            timer += 4f;
        }
        else if (score >= 70 && score < 80)
        {
            timer += 6f;
        }
        else if (score >= 80 && score < 90)
        {
            timer += 8f;
        }
        else if (score >= 90 && score <= 100)
        {
            timer += 10f;
        }
        InvokeRepeating("UpdateTimerDisplay", 0f, 1f);
    }

    private void UpdateTimerDisplay()
    {
        timer -= 1f;
        timerDisplay.text = timer.ToString() + " seconds";
        if (timer <= 0f)
        {
            PlayerPrefs.SetString("FinishedMaze", "No");
            CancelInvoke("UpdateTimerDisplay");
            timerDisplay.text = "0 seconds";
            hintPanel.SetActive(true);
        }
    }

    public void CloseHintPanel()
    {
        hintPanel.SetActive(false);
    }
}
