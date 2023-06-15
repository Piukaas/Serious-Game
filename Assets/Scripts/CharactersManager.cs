using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactersManager : MonoBehaviour
{
    public GameObject mark;
    public GameObject emma;
    public GameObject finn;
    public Text markText;
    public Text emmaText;
    public Text finnText;

    public Color disabledColor = Color.gray;

    void Start()
    {
        PlayerPrefs.DeleteKey("Character");
        PlayerPrefs.DeleteKey("Score");

        int level = PlayerPrefs.GetInt("Level", 1);
        if (level < 2)
        {
            SetColliderEnabled(mark, false);
            SetColliderEnabled(emma, false);
            SetColliderEnabled(finn, false);
            markText.text = "Locked";
            emmaText.text = "Locked";
            finnText.text = "Locked";
        }
        else if (level == 2 || level == 3)
        {
            SetColliderEnabled(mark, true);
            SetColliderEnabled(emma, false);
            SetColliderEnabled(finn, false);
            markText.text = "Medium";
            emmaText.text = "Locked";
            finnText.text = "Locked";
        }
        else if (level == 4 || level == 5)
        {
            SetColliderEnabled(mark, true);
            SetColliderEnabled(emma, true);
            SetColliderEnabled(finn, false);
            markText.text = "Medium";
            emmaText.text = "Hard";
            finnText.text = "Locked";
        }
        else if (level >= 6)
        {
            SetColliderEnabled(mark, true);
            SetColliderEnabled(emma, true);
            SetColliderEnabled(finn, true);
            markText.text = "Medium";
            emmaText.text = "Hard";
            finnText.text = "Expert";
        }
    }

    private void SetColliderEnabled(GameObject character, bool isEnabled)
    {
        Collider2D collider = character.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = isEnabled;
            if (!isEnabled)
            {
                SpriteRenderer spriteRenderer = character.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = disabledColor;
                }
            }
        }
    }
}
