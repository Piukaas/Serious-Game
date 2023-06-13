using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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