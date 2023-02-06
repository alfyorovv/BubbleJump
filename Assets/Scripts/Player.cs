using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 12; 
    private bool isWalled = true;
    private bool canJump = true;
    private bool canGetDamage = true;
    private bool isShielded = false;
    private float direction = 1;

    public bool isLeftWall = true;
    public int hp;

    private Rigidbody2D rb;
    private GameOverPanel gameOverPanel;
    private AnimationsController animController;
    private AudioManager audioManager;

    public GameObject child1, child2, coinParticles, heartParticles, shield, shieldParticles;
    public SpriteRenderer sprite1, sprite2;
    public Animator playerAnimator;
    public Text hpText;
    public Sprite[] skins;

    private void Awake()
    {
        animController = FindObjectOfType<AnimationsController>();
        gameOverPanel = FindObjectOfType<GameOverPanel>();
        audioManager = FindObjectOfType<AudioManager>();

        rb = GetComponent<Rigidbody2D>();
        sprite1 = child1.GetComponent<SpriteRenderer>();
        sprite2= child2.GetComponent<SpriteRenderer>();
        playerAnimator = gameObject.GetComponent<Animator>();

        hp = 3;
    }

    private void Start()
    {
        sprite1.sprite = skins[PlayerPrefs.GetInt("currentSkin")];
        sprite2.sprite = skins[PlayerPrefs.GetInt("currentSkin") + 1];
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) && isWalled && canJump)
        {
            Jump();
        }

        if (hp <= 0)
        {
            GameOver();
        }

        hpText.text = "x" + hp;

        if (isShielded)
        {
            canGetDamage = false;
        }
    }

    private void Jump()
    {
        Vector2 force = new Vector2(speed * direction, 0); //Player force and direction

        animController.SetJumpTrigger();
        isLeftWall = !isLeftWall;
        rb.AddForce(force, ForceMode2D.Impulse);
        direction *= -1;
        audioManager.audioSource.Play();
    }

    private void GameOver()
    {
        gameOverPanel.GameOver();
        PlayerPrefs.SetInt("tempAds", PlayerPrefs.GetInt("tempAds") + 1);
        hp = 1;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWalled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
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

    //Function to check if pointer on pause button
    public void SetCanJump(bool state)
    {
        canJump = state;
    }

    //Player can't get damage after getting damage
    private IEnumerator Flashing(int flashes)
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

     
