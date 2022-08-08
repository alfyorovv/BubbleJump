using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsMovement : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }
}
