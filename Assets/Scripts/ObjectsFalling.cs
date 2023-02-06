using UnityEngine;

public class ObjectsFalling : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (gameObject.tag == "Obstacle")
        {
            speed = Random.Range(4f, 6f);
        }
        else if (gameObject.tag == "Coin" || gameObject.tag == "Heal" || gameObject.tag == "Shield")
        {
            speed = Random.Range(1.5f, 2.5f);
        }

        rb.velocity = new Vector2(0, -speed);
    }
}
