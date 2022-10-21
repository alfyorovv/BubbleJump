using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    bool isWalled = true;
    bool canJump = true;
    bool canGetDamage = true;
    bool isShielded = false;
    public bool isLeftWall = true;

    [SerializeField] float speed = 12;
    float direction = 1;
    public int hp;

    Rigidbody2D rb;
    public GameObject child1, child2, coinParticles, heartParticles, shield, shieldParticles;
    public SpriteRenderer sprite1, sprite2;
    GameOverPanel gameOverPanel;
    public Animator playerAnimator;
    AnimationsController animController;
    public Text hpText;
    AudioManager audioManager;
    public Sprite[] skins;

    void Awake()
    {
        animController = FindObjectOfType<AnimationsController>();
        playerAnimator = gameObject.GetComponent<Animator>();
        gameOverPanel = FindObjectOfType<GameOverPanel>();
        rb = GetComponent<Rigidbody2D>();
        sprite1 = child1.GetComponent<SpriteRenderer>();
        sprite2= child2.GetComponent<SpriteRenderer>();
        audioManager = FindObjectOfType<AudioManager>();
        hp = 3;
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        sprite1.sprite = skins[PlayerPrefs.GetInt("currentSkin")];
        sprite2.sprite = skins[PlayerPrefs.GetInt("currentSkin") + 1];
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
            audioManager.audioSource.Play();

        }

        //Game over
        if(hp<=0)
        {
            gameOverPanel.GameOver();
            PlayerPrefs.SetInt("tempAds", PlayerPrefs.GetInt("tempAds") + 1);
            Debug.Log(PlayerPrefs.GetInt("tempAds"));
            hp = 1;
        }

        hpText.text = "x" + hp;

        if (isShielded)
        {
            canGetDamage = false;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Obstacle" && canGetDamage)
        {
            hp -= 1;
            StartCoroutine("Flashing", 5);
        }

        else if (collider.gameObject.tag == "Coin")
        {
            Instantiate(coinParticles, gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
        }

        else if(collider.gameObject.tag == "Heal")
        {
            Instantiate(heartParticles, gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            hp += 1;
        }

        else if (collider.gameObject.tag == "Shield" && !isShielded)
        {
            Instantiate(shield, gameObject.transform.position, Quaternion.identity, gameObject.transform);
            Destroy(collider.gameObject);
            StartCoroutine("Shield");
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

    //Player can't get damage after getting damage
    IEnumerator Flashing(int flashes)
    {
        canGetDamage = false;
        for (int i = 0; i < flashes; i++)
        {
            sprite1.enabled = false;
            sprite2.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite1.enabled = true;
            sprite2.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        canGetDamage = true;
    }

    IEnumerator Shield()
    {
        canGetDamage = false;
        isShielded = true;
        yield return new WaitForSeconds(10f);
        canGetDamage = true;
        Destroy(GameObject.Find("Shield(Clone)"));
        Instantiate(shieldParticles, gameObject.transform.position, Quaternion.identity);
        isShielded = false;
    }
}

     
