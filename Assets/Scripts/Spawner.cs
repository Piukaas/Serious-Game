using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject heart;
    public Text timerDisplay;
    private SceneManager sceneManager;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.5f;

    private float timer = 10f;

    private void Awake()
    {
        sceneManager = FindObjectOfType<SceneManager>();
    }

    private IEnumerator Start()
    {
        if (PlayerPrefs.GetString("Character") == "Floor")
        {
            timer = 10f;
        }
        else if (PlayerPrefs.GetString("Character") == "Mark")
        {
            timer = 20f;
        }
        else if (PlayerPrefs.GetString("Character") == "Emma")
        {
            timer = 30f;
        }
        else if (PlayerPrefs.GetString("Character") == "Finn")
        {
            timer = 40f;
        }
        StartCoroutine(UpdateTimerDisplay());
        yield return new WaitForSeconds(timer);
        // destroy all hearts
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject heart in hearts)
        {
            Destroy(heart);
        }
        Destroy(gameObject);
        Victory();
    }


    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {
                startTimeBtwSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private IEnumerator UpdateTimerDisplay()
    {
        while (timer > 0f)
        {
            timerDisplay.text = timer.ToString() + " seconds";
            yield return new WaitForSeconds(1f);
            timer--;
        }
        timerDisplay.text = "0 seconds";
    }

    void Victory()
    {
        sceneManager.DeadOrAliveButton();
    }
}
