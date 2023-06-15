using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartoonHeart : MonoBehaviour
{
    public float speed;
    public GameObject effect;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
    }
}
