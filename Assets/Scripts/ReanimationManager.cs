using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReanimationManager : MonoBehaviour
{
    public GameObject patientImage;
    public Sprite floorSprite;
    public Sprite markSprite;
    public Sprite emmaSprite;
    public Sprite finnSprite;

    void Start()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            patientImage.GetComponent<SpriteRenderer>().sprite = floorSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            patientImage.GetComponent<SpriteRenderer>().sprite = markSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            patientImage.GetComponent<SpriteRenderer>().sprite = emmaSprite;
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            patientImage.GetComponent<SpriteRenderer>().sprite = finnSprite;
        }
    }
}
