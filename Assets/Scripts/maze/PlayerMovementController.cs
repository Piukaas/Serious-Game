using System;
using UnityEngine;

namespace maze
{
    public class PlayerMovementController : MonoBehaviour
    {
        private SceneManager sceneManager;
        public float moveSpeed = 10f;
        public Sprite floorSprite;
        public Sprite markSprite;
        public Sprite emmaSprite;
        public Sprite finnSprite;

        private Rigidbody2D _rb;

        private void Start()
        {
            sceneManager = FindObjectOfType<SceneManager>();
            if (PlayerPrefs.GetString("Character") == "Floor")
            {
                GetComponent<SpriteRenderer>().sprite = floorSprite;
            }
            else if (PlayerPrefs.GetString("Character") == "Mark")
            {
                GetComponent<SpriteRenderer>().sprite = markSprite;
            }
            else if (PlayerPrefs.GetString("Character") == "Emma")
            {
                GetComponent<SpriteRenderer>().sprite = emmaSprite;
            }
            else if (PlayerPrefs.GetString("Character") == "Finn")
            {
                GetComponent<SpriteRenderer>().sprite = finnSprite;
            }
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            _rb.velocity = new Vector2(moveHorizontal, moveVertical) * moveSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Finish"))
            {
                Destroy(gameObject);
                sceneManager.ResultButton();
            }
        }
    }
}