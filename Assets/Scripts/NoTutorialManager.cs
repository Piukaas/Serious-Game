using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoTutorialManager : MonoBehaviour
{
    public Text titleText;
    public Text explanationText;
    public GameObject characterObject;
    public Sprite floorSprite;
    public Sprite markSprite;
    public Sprite emmaSprite;
    public Sprite finnSprite;

    void Start()
    {
        int heartBeat = PlayerPrefs.GetInt("Score");
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            titleText.text = "Floor is gezond! - Hartslag: " + heartBeat + " BPM";
            explanationText.text = "Als gevolg van de juiste keuzes heeft Floor geen hartaanval gekregen.";
            characterObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            titleText.text = "Mark is gezond! - Hartslag: " + heartBeat + " BPM";
            explanationText.text = "Als gevolg van de juiste keuzes heeft Mark geen hartaanval gekregen.";
            characterObject.GetComponent<SpriteRenderer>().sprite = markSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            titleText.text = "Emma is gezond! - Hartslag: " + heartBeat + " BPM";
            explanationText.text = "Als gevolg van de juiste keuzes heeft Emma geen hartaanval gekregen.";
            characterObject.GetComponent<SpriteRenderer>().sprite = emmaSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            titleText.text = "Finn is gezond! - Hartslag: " + heartBeat + " BPM";
            explanationText.text = "Als gevolg van de juiste keuzes heeft Finn geen hartaanval gekregen.";
            characterObject.GetComponent<SpriteRenderer>().sprite = finnSprite;
        }
    }
}
