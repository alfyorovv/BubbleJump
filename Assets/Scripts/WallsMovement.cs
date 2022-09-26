using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }

}
