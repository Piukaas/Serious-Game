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

    [System.Serializable]
    public class Question
    {
        public int scenarioId;
        public string description;
        public string question;
        public AnswerOption answerOption;
        public string correctAnswer;
        public string difficulty;
        public string answerExplanation;
    }

    [System.Serializable]
    public class AnswerOption
    {
        public string yes;
        public string no;
    }

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
        string jsonFile = "Data/scenarios-easy";
        
        switch (character)
        {
            case "Floor":
                jsonFile = "Data/scenarios-easy";
                break;
                
            case "Mark":
                jsonFile = "Data/scenarios-medium";
                break;
                
            case "Emma":
                jsonFile = "Data/scenarios-hard";
                break;
                
            case "Finn":
                jsonFile = "Data/scenarios-expert";
                break;
                
            default:
                break;
        }
        
        TextAsset jsonData = Resources.Load<TextAsset>(jsonFile);
        questions = new List<Question>(JsonHelper.FromJson<Question>(jsonData.text));
        questions = RandomizeList(questions);
        questions.RemoveRange(3, questions.Count - 3);
        string jsonQuestions = JsonHelper.ToJson(questions);
        PlayerPrefs.SetString("Questions", jsonQuestions);
    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            string jsonWrapped = "{\"items\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(jsonWrapped);
            return wrapper.items;
        }

        public static string ToJson<T>(List<T> list)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.items = list.ToArray();
            return JsonUtility.ToJson(wrapper);
        }

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] items;
        }
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
        if (currentQuestionIndex >= 3) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Result");
        } else {
            Question currentQuestion = questions[currentQuestionIndex];
            descriptionText.text = currentQuestion.description;
            questionText.text = currentQuestion.question;
            scenarioCount.text = "Scenario " + (currentQuestionIndex + 1);
        }
    }

    public void OnYesButtonClick()
    {
        if (questions[currentQuestionIndex].answerOption.yes == questions[currentQuestionIndex].correctAnswer)
        {
            PlayerPrefs.SetInt("CorrectAnswers", PlayerPrefs.GetInt("CorrectAnswers") + 1);
        }
        currentQuestionIndex++;
        ShowCurrentQuestion();
    }

    public void OnNoButtonClick()
    {
        if (questions[currentQuestionIndex].answerOption.no == questions[currentQuestionIndex].correctAnswer)
        {
            PlayerPrefs.SetInt("CorrectAnswers", PlayerPrefs.GetInt("CorrectAnswers") + 1);
        }
        currentQuestionIndex++;
        ShowCurrentQuestion();
    }
}