using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Text levelText;
    public Text xpText;
    public Text requiredXpText;
    public Text percentageText;
    public Image progressBar;
    public Text xpReceived;

    void Start()
    {
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        if (!PlayerPrefs.HasKey("Xp"))
        {
            PlayerPrefs.SetInt("Xp", 0);
        }
        if (!PlayerPrefs.HasKey("RequiredXp"))
        {
            PlayerPrefs.SetInt("RequiredXp", 50);
        }

        SetText();
    }

    public void SetText() {
        if(levelText){
            levelText.text = GetLevel().ToString();
        }

        if(xpText){
            xpText.text = GetXp().ToString();
        }

        if(requiredXpText){
            requiredXpText.text = GetRequiredXp().ToString();
        }

        if(percentageText){
            percentageText.text = GetXpPercentageAsFloat().ToString() + "%";
        }

        if(progressBar){
            progressBar.fillAmount = GetXpPercentageAsFloat() / 100f;
        }
    }

    public void AddXp(int xp)
    {
        int currentXp = PlayerPrefs.GetInt("Xp");
        int newXp = currentXp + xp;
        PlayerPrefs.SetInt("Xp", newXp);

        if(xpReceived){
            xpReceived.text = "+" + xp.ToString() + " XP";
        }

        AnimateProgressBar(currentXp, newXp);

        // if higher than required xp for next level, level up
        if (newXp >= GetRequiredXp())
        {
            LevelUp();
        }

        SetText();
    }

    public void AddXpBased() {
        // add xp based on correct answers. 4 - 6 xp per correct answer
        int correctAnswers = PlayerPrefs.GetInt("CorrectAnswers");
        int xp = Random.Range(4, 7) * correctAnswers;
        string character = PlayerPrefs.GetString("Character");

        if(character == "Floor"){
            xp = Mathf.RoundToInt(xp * 0.95f);
        } else if(character == "Mark"){
            xp = Mathf.RoundToInt(xp * 1.07f);
        } else if(character == "Emma"){
            xp = Mathf.RoundToInt(xp * 1.14f);
        } else if(character == "Finn"){
            xp = Mathf.RoundToInt(xp * 1.22f);
        }

        AddXp(xp);
        PlayerPrefs.SetInt("ReceivedXp", xp);
    }

    public int GetLevel()
    {
        return PlayerPrefs.GetInt("Level");
    }

    public int GetXp()
    {
        return PlayerPrefs.GetInt("Xp");
    }

    public int GetRequiredXp()
    {
        return PlayerPrefs.GetInt("RequiredXp");
    }

    public int GetXpPercentageAsFloat()
    {
        int currentXp = GetXp();
        int requiredXp = GetRequiredXp();
        return Mathf.RoundToInt((float)currentXp / requiredXp * 100);
    }
    
    public void LevelUp()
    {
        int currentLevel = GetLevel();
        int newLevel = currentLevel + 1;
        int requiredXp = GetRequiredXp();
        PlayerPrefs.SetInt("Level", newLevel);
        PlayerPrefs.SetInt("Xp", 0);
        PlayerPrefs.SetInt("RequiredXp", Mathf.RoundToInt(requiredXp * 1.05f));
    }

    private void AnimateProgressBar(int currentXp, int newXp)
    {
        float oldPercentage = (float)currentXp / GetRequiredXp() * 100f;
        float newPercentage = (float)newXp / GetRequiredXp() * 100f;
        StartCoroutine(UpdateProgressBarAnimation(oldPercentage, newPercentage));
    }

    private IEnumerator UpdateProgressBarAnimation(float oldPercentage, float newPercentage, float duration = 0.5f)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float currentPercentage = Mathf.Lerp(oldPercentage, newPercentage, elapsedTime / duration);
            progressBar.fillAmount = currentPercentage / 100f;
            yield return null;
        }

        progressBar.fillAmount = Mathf.RoundToInt(newPercentage) / 100f;
    }

}
