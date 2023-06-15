using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text questionText;
    public Text percentageText;
    public Text answerExplanationText;
    public Text resultatenText;
    public Button nextButton;

    private List<Question> questions;
    private int currentQuestionIndex;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        LoadQuestions();
        ShowCurrentQuestion();
        nextButton.onClick.AddListener(OnNextButtonClick);

        // wait 2 seconds and then add 10 xp
        StartCoroutine(AddXpAfterDelay(1));
    }

    IEnumerator AddXpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        levelManager.AddXpBased();
    }

    private void LoadQuestions()
    {
        string storedQuestions = PlayerPrefs.GetString("Questions");
        // Remove "items" key from JSON
        storedQuestions = storedQuestions.Substring(9, storedQuestions.Length - 10);
        questions = new List<Question>(JsonHelper.FromJson<Question>(storedQuestions));

        int correctAnswers = PlayerPrefs.GetInt("CorrectAnswers");
        int totalQuestions = questions.Count;
        float percentage = (float)correctAnswers / totalQuestions * 100;
        percentageText.text = Mathf.RoundToInt(percentage) + "%";
    }

    private void ShowCurrentQuestion()
    {
        resultatenText.text = "Resultaten AI (" + (currentQuestionIndex + 1) + "/" + questions.Count + ")";
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.question;
        answerExplanationText.text = currentQuestion.answerExplanation;
    }

    public void OnNextButtonClick()
    {
        if (currentQuestionIndex < questions.Count - 1)
        {
            currentQuestionIndex++;
            ShowCurrentQuestion();
            // if last question, change button text to "Ga terug naar menu"
            if (currentQuestionIndex == questions.Count - 1)
            {
                nextButton.GetComponentInChildren<Text>().text = "Menu";
            }
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
        }
    }
}