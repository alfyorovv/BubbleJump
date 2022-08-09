using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isWalled = true;

    float direction = 1;
    float speed = 12;
    public int hp;
    public int coins = 0;

    Rigidbody2D rb;
    GameOverPanel gameOverPanel; 

    void Start()
    {
        gameOverPanel = FindObjectOfType<GameOverPanel>(); 
        rb = GetComponent<Rigidbody2D>();
        hp = 3;
    }

    void Update()
    {

        Vector2 force = new Vector2(speed*direction, 0); //Player force and direction

        //Player movement
        if (Input.GetMouseButtonDown(0) && isWalled == true)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            direction *= -1;
        }

        //Game over
        if(hp<=0)
        {
            Destroy(gameObject);
            gameOverPanel.GameOver();
        }

        coins = PlayerPrefs.GetInt("coins"); //Change and save coins
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle")
        {
            hp -= 1;
        }

        if (collider.gameObject.tag == "Coin")
        {
            Destroy(collider.gameObject);
            PlayerPrefs.SetInt("coins", coins+1);
        }
        
    }
}

     
