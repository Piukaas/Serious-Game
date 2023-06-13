using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("Character");
    }
}
