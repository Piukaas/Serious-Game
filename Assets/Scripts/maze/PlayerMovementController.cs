using System;
using UnityEngine;

namespace maze
{
    public class PlayerMovementController : MonoBehaviour
    {
        public float moveSpeed = 125f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            
            _rb.AddForce(new Vector2(moveHorizontal, moveVertical) * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("AED"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}