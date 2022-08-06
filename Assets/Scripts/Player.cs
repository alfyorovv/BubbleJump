using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isWalled = true;
    public Rigidbody2D rb;
    float direction = 1;
    float speed = 200;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 force = new Vector2(speed*direction, 0);
        if (Input.GetMouseButtonDown(0) && isWalled == true)
        {
            Debug.Log("Clicked");
            rb.AddForce(force, ForceMode2D.Force);
            direction *= -1;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall") 
            isWalled = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            isWalled = false;
    }
}

     
