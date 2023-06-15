using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private SceneManager sceneManager;

    public Text heartRateDisplay;
    public GameObject spawner;
    public Animator patient;
    public GameObject oofSound;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        heartRateDisplay.text = score.ToString() + " BPM";
    }

    void Update()
    {
        PlayerPrefs.SetInt("Score", score);

        if (score <= 0)
        {
            heartRateDisplay.text = "0 BPM";
            GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
            foreach (GameObject heart in hearts)
            {
                Destroy(heart);
            }
            spawner.SetActive(false);
            PlayerPrefs.SetInt("Score", 0);
            StartCoroutine(DelayedGameOver());
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
        heartRateDisplay.text = score.ToString() + " BPM";
    }

    IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(2f);
        GameOver();
    }

    void GameOver()
    {
        sceneManager.DeadOrAliveButton();
    }
}
