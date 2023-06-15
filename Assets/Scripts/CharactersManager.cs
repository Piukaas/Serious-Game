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
            markText.text = "Locked";
            SetColliderEnabled(emma, false);
            emmaText.text = "Locked";
            SetColliderEnabled(finn, false);
            finnText.text = "Locked";
        }
        else if (level == 2)
        {
            SetColliderEnabled(mark, true);
            markText.text = "Medium";
            SetColliderEnabled(emma, false);
            emmaText.text = "Locked";
            SetColliderEnabled(finn, false);
            finnText.text = "Locked";
        }
        else if (level == 4)
        {
            SetColliderEnabled(mark, true);
            markText.text = "Medium";
            SetColliderEnabled(emma, true);
            emmaText.text = "Hard";
            SetColliderEnabled(finn, false);
            finnText.text = "Locked";
        }
        else if (level == 6)
        {
            SetColliderEnabled(mark, true);
            markText.text = "Medium";
            SetColliderEnabled(emma, true);
            emmaText.text = "Hard";
            SetColliderEnabled(finn, true);
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
