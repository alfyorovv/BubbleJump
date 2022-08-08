using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject[] walls;

    Vector2 spawnPosition;
    int rand;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
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
