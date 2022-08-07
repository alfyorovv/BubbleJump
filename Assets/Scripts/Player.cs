using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isWalled = true;
    Rigidbody2D rb;
    float direction = 1;
    float speed = 12;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 force = new Vector2(speed*direction, 0);
        if (Input.GetMouseButtonDown(0) && isWalled == true)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            direction *= -1;
        }
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWalled = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWalled = false;
        }
    }


}

     
