using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (gameObject.tag == "Obstacle")
        {
            speed = Random.Range(4f, 6f);
        }
        else if(gameObject.tag == "Coin")
        {
            speed = Random.Range(1.5f, 2.5f);
        }

        rb.velocity = new Vector2(0, -speed);
    }
}
