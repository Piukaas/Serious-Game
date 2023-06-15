using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleManager : MonoBehaviour
{
    private bool heartDestroyed = true;
    private ScoreManager scoreManager;
    public Animator hands;
    public GameObject popSound;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (heartDestroyed)
            {
                GameObject heartObject = GameObject.FindGameObjectWithTag("Heart");
                scoreManager.Damage();
                Destroy(heartObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Heart"))
        {
            StartCoroutine(DestroyHeartOnInput(collision.gameObject));
        }
    }

    private IEnumerator DestroyHeartOnInput(GameObject heartObject)
    {
        heartDestroyed = false;
        while (!heartDestroyed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Instantiate(popSound, transform.position, Quaternion.identity);
                hands.SetTrigger("Push");
                Destroy(heartObject);
                heartDestroyed = true;
            }
            yield return null;
        }
    }
}
