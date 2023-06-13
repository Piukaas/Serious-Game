using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfopageManager : MonoBehaviour
{
    public Text titleText;
    public Text infoText;
    public GameObject characterObject;
    public Sprite floorSprite;
    public Sprite markSprite;
    public Sprite emmaSprite;
    public Sprite finnSprite;

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            titleText.text = "Floor";
            infoText.text = "Floor is een hartpatiënt. Ze heeft net de eerste scan achter de rug en die waren redelijk goed. Hierbij zijn haar overlevingskansen hoog. Maar moet er wel actie worden ondernomen?";
            characterObject.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            titleText.text = "Mark";
            infoText.text = "Mark heeft al enige tijd last van hart- en vaatproblemen. Recente onderzoeken hebben aangetoond dat zijn conditie verslechtert, en er zijn tekenen van vernauwde kransslagaders. Hoewel zijn toestand serieus is, is er nog ruimte voor behandeling en verbetering.";
            characterObject.GetComponent<SpriteRenderer>().sprite = markSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            titleText.text = "Emma";
            infoText.text = "Emma heeft al meerdere hartaanvallen gehad en kampt met een zwakke hartspier. Haar conditie is zeer kwetsbaar en de behandelingsopties zijn beperkt. De beslissingen die je neemt, hebben een grote invloed op haar leven en overlevingskansen.";
            characterObject.GetComponent<SpriteRenderer>().sprite = emmaSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            titleText.text = "Finn";
            infoText.text = "Finn heeft een complexe medische geschiedenis met meerdere hartoperaties en onderliggende aandoeningen zoals diabetes en hoge bloeddruk. Zijn hart- en vaatproblemen zijn zeer ernstig en hebben een significante impact op zijn kwaliteit van leven. De mogelijkheden zijn beperkt vanwege de complexiteit en ernst van zijn situatie.";
            characterObject.GetComponent<SpriteRenderer>().sprite = finnSprite;
        }
    }
}
