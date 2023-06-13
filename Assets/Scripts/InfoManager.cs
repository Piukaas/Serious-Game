using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    public Text titleText;
    public Text ageText;
    public Text jobText;
    public Text infoText;
    public GameObject characterObject;
    public Sprite floorSprite;
    public Sprite markSprite;
    public Sprite emmaSprite;
    public Sprite finnSprite;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Data/characters-info");

        if (jsonFile != null)
        {
            string jsonString = jsonFile.text;
            CharacterInfo[] characters = JsonHelper.FromJson<CharacterInfo>(jsonString);


            string selectedCharacter = PlayerPrefs.GetString("Character");
            CharacterInfo selectedInfo = null;

            foreach (CharacterInfo characterInfo in characters)
            {
                if (characterInfo.name == selectedCharacter)
                {
                    selectedInfo = characterInfo;
                    break;
                }
            }

            if (selectedInfo != null)
            {
                titleText.text = selectedInfo.name;
                infoText.text = selectedInfo.info;

                if (ageText != null)
                {
                    ageText.text = "Leeftijd: " + selectedInfo.age + " jaar";
                }

                if (jobText != null)
                {
                    jobText.text = "Beroep: " + selectedInfo.job;
                }

                if (selectedCharacter == "Floor")
                {
                    characterObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
                }
                else if (selectedCharacter == "Mark")
                {
                    characterObject.GetComponent<SpriteRenderer>().sprite = markSprite;
                }
                else if (selectedCharacter == "Emma")
                {
                    characterObject.GetComponent<SpriteRenderer>().sprite = emmaSprite;
                }
                else if (selectedCharacter == "Finn")
                {
                    characterObject.GetComponent<SpriteRenderer>().sprite = finnSprite;
                }
            }
        }
        else
        {
            Debug.LogError("Failed to load characters-info JSON file.");
        }
    }
}