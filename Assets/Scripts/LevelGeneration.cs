using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private Vector2 spawnPosition;
    private int rand;

    public GameObject spawnPoint;
    public GameObject[] walls;

    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void Start()
    {
        spawnPosition = spawnPoint.transform.position;
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "SpawnTrigger")
        {
            rand = Random.Range(0, walls.Length);
            Instantiate(walls[rand], spawnPosition, Quaternion.identity);
        }
    }

}
