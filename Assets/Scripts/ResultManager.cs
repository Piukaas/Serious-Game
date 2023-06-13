using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public Text questionText;
    public Text percentageText;
    public Text answerExplanationText;
    public Button nextButton;

    private List<Question> questions;
    private int currentQuestionIndex;

    void Start()
    {
        LoadQuestions();
        ShowCurrentQuestion();
        nextButton.onClick.AddListener(OnNextButtonClick);
    }

    private void LoadQuestions()
    {
        string storedQuestions = PlayerPrefs.GetString("Questions");
        // Remove "items" key from JSON
        storedQuestions = storedQuestions.Substring(9, storedQuestions.Length - 10);
        Debug.Log(storedQuestions);
        questions = new List<Question>(JsonHelper.FromJson<Question>(storedQuestions));

        int correctAnswers = PlayerPrefs.GetInt("CorrectAnswers");
        int totalQuestions = questions.Count;
        float percentage = (float)correctAnswers / totalQuestions * 100;
        percentageText.text = Mathf.RoundToInt(percentage) + "%";
    }

    private void ShowCurrentQuestion()
    {
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
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Home");
        }
    }
}