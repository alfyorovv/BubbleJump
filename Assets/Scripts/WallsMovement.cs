using UnityEngine;

public class WallsMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    private void Update()
    {
        rb.velocity = new Vector2(0, -speed);
    }

}
