using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    public Text heartRateDisplay;
    public GameObject spawner;
    public Animator patient;
    public GameObject oofSound;

    void Start()
    {
        if (PlayerPrefs.GetInt("Score") == 0)
        {
            score = 100;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score");
        }
        heartRateDisplay.text = score.ToString();
    }

    void Update()
    {
        if (score <= 0)
        {
            heartRateDisplay.text = "0";
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            foreach (GameObject heart in hearts)
            {
                Destroy(heart);
            }
            spawner.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            Damage();
        }
    }

    public void Damage()
    {
        score -= Random.Range(5, 10);
        Instantiate(oofSound, transform.position, Quaternion.identity);
        patient.SetTrigger("Damage");
        heartRateDisplay.text = score.ToString();
    }
}
