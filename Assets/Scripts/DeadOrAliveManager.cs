using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadOrAliveManager : MonoBehaviour
{
    public Text survivorText;
    public Text deadText;
    public Text explanationText;
    public Text explanationSurvivorText;
    public Button priceButton;
    public Button retryButton;
    public GameObject characterObject;
    public Sprite floorSprite;
    public Sprite markSprite;
    public Sprite emmaSprite;
    public Sprite finnSprite;

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            survivorText.text = "Floor is levend!";
            deadText.text = "Floor is overleden";
            explanationText.text = "Helaas heeft Floor de reanimatie niet overleefd, ondanks jouw inspanningen om haar leven te redden. Het is een tragisch verlies en haar afwezigheid zal diep gevoeld worden.";
            explanationSurvivorText.text = "Gelukkig heeft Floor de reanimatie succesvol doorstaan dankzij jouw snelle reactie en effectieve handelingen. Door jouw inspanningen is haar leven gered en heeft Floor nu de kans om verder te herstellen en haar leven voort te zetten. Jouw moed en vaardigheden hebben het verschil gemaakt.";
            characterObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            survivorText.text = "Mark is levend!";
            deadText.text = "Mark is overleden";
            explanationText.text = "Helaas heeft Mark de reanimatie niet overleefd, ondanks jouw inspanningen om zijn leven te redden. Het is een tragisch verlies en zijn afwezigheid zal diep gevoeld worden.";
            explanationSurvivorText.text = "Gelukkig heeft Mark de reanimatie succesvol doorstaan dankzij jouw snelle reactie en effectieve handelingen. Door jouw inspanningen is zijn leven gered en heeft Mark nu de kans om verder te herstellen en zijn leven voort te zetten. Jouw moed en vaardigheden hebben het verschil gemaakt.";
            characterObject.GetComponent<SpriteRenderer>().sprite = markSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            survivorText.text = "Emma is levend!";
            deadText.text = "Emma is overleden";
            explanationText.text = "Helaas heeft Emma de reanimatie niet overleefd, ondanks jouw inspanningen om haar leven te redden. Het is een tragisch verlies en haar afwezigheid zal diep gevoeld worden.";
            explanationSurvivorText.text = "Gelukkig heeft Emma de reanimatie succesvol doorstaan dankzij jouw snelle reactie en effectieve handelingen. Door jouw inspanningen is haar leven gered en heeft Emma nu de kans om verder te herstellen en haar leven voort te zetten. Jouw moed en vaardigheden hebben het verschil gemaakt.";
            characterObject.GetComponent<SpriteRenderer>().sprite = emmaSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            survivorText.text = "Finn is levend!";
            deadText.text = "Finn is overleden";
            explanationText.text = "Helaas heeft Finn de reanimatie niet overleefd, ondanks jouw inspanningen om zijn leven te redden. Het is een tragisch verlies en zijn afwezigheid zal diep gevoeld worden.";
            explanationSurvivorText.text = "Gelukkig heeft Finn de reanimatie succesvol doorstaan dankzij jouw snelle reactie en effectieve handelingen. Door jouw inspanningen is zijn leven gered en heeft Finn nu de kans om verder te herstellen en zijn leven voort te zetten. Jouw moed en vaardigheden hebben het verschil gemaakt.";
            characterObject.GetComponent<SpriteRenderer>().sprite = finnSprite;
        }

        if (PlayerPrefs.GetInt("Score") <= 0)
        {
            survivorText.gameObject.SetActive(false);
            explanationSurvivorText.gameObject.SetActive(false);
            priceButton.gameObject.SetActive(false);
        }
        else
        {
            deadText.gameObject.SetActive(false);
            explanationText.gameObject.SetActive(false);
            retryButton.gameObject.SetActive(false);
        }

    }
}
