using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public Text descriptionText;
    public Text questionText;
    public Text scenarioCount;
    public Button yesButton;
    public Button noButton;

    public List<Question> questions;
    private int currentQuestionIndex;

    void Start()
    {
        LoadQuestions();
        ShowCurrentQuestion();
        yesButton.onClick.AddListener(OnYesButtonClick);
        noButton.onClick.AddListener(OnNoButtonClick);
        PlayerPrefs.SetInt("CorrectAnswers", 0);
    }

    private void LoadQuestions()
    {
        string character = PlayerPrefs.GetString("Character");

        string jsonFile = character switch
        {
            "Floor" => "Data/scenarios-easy",
            "Mark" => "Data/scenarios-medium",
            "Emma" => "Data/scenarios-hard",
            "Finn" => "Data/scenarios-expert",
            _ => "Data/scenarios-easy"
        };

        TextAsset jsonData = Resources.Load<TextAsset>(jsonFile);
        questions = new List<Question>(JsonHelper.FromJson<Question>(jsonData.text));
        questions = RandomizeList(questions);
        questions.RemoveRange(3, questions.Count - 3);
        string jsonQuestions = JsonHelper.ToJson(questions);
        PlayerPrefs.SetString("Questions", jsonQuestions);
    }

    private List<T> RandomizeList<T>(List<T> inputList)
    {
        List<T> randomList = new List<T>();

        while (inputList.Count > 0)
        {
            int randomIndex = Random.Range(0, inputList.Count);
            randomList.Add(inputList[randomIndex]);
            inputList.RemoveAt(randomIndex);
        }

        return randomList;
    }

    private void ShowCurrentQuestion()
    {
        if (currentQuestionIndex >= 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        }
        else
        {
            Question currentQuestion = questions[currentQuestionIndex];
            descriptionText.text = currentQuestion.description;
            questionText.text = currentQuestion.question;
            scenarioCount.text = "Scenario " + (currentQuestionIndex + 1);
        }
    }

    public void OnYesButtonClick()
    {
        OnButtonClick("yes");
    }

    public void OnNoButtonClick()
    {
        OnButtonClick("no");
    }

    private void OnButtonClick(string answer)
    {
        if (questions[currentQuestionIndex].correctAnswer == answer)
        {
            PlayerPrefs.SetInt("CorrectAnswers", PlayerPrefs.GetInt("CorrectAnswers") + 1);
        }
        currentQuestionIndex++;
        ShowCurrentQuestion();
    }
}