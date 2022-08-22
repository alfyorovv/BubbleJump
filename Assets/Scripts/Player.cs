using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool isWalled = true;
    bool canJump = true;
    public bool isLeftWall = true;

    float direction = 1;
    float speed = 12;
    public int hp;

    Rigidbody2D rb;
    GameOverPanel gameOverPanel;
    public Animator playerAnimator;
    AnimationsController animController;
    public Text hpText;

    void Start()
    {
        animController = FindObjectOfType<AnimationsController>();
        playerAnimator = gameObject.GetComponent<Animator>();
        gameOverPanel = FindObjectOfType<GameOverPanel>();
        rb = GetComponent<Rigidbody2D>();
        hp = 3;
    }

    void Update()
    {

        Vector2 force = new Vector2(speed*direction, 0); //Player force and direction

        //Player movement
        if (Input.GetMouseButtonDown(0) && isWalled && canJump)
        {
            animController.setJumpTrigger();
            isLeftWall = !isLeftWall;
            rb.AddForce(force, ForceMode2D.Impulse);
            direction *= -1;
        }

        //Game over
        if(hp<=0)
        {
            gameOverPanel.GameOver();
        }

        hpText.text = "x" + hp;
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
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
        }
        
    }

    //Functions to check if mouse on pause button
    public void CanJump()
    {
        canJump = true;
    }

    public void CantJump()
    {
        canJump = false;
    }
}

     
