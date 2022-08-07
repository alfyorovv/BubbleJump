using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject walls;
    public GameObject spawnPoint;
    public GameObject spike;
    GameObject[] obstacleSpawnPoints;

    Vector2 spawnPosition;
    int rand;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        spawnPosition = spawnPoint.transform.position;
        obstacleSpawnPoints = GameObject.FindGameObjectsWithTag("ObstacleSpawnPoint");

        foreach (GameObject obj in obstacleSpawnPoints)
        {
           rand = Random.Range(0, 10);
           if (rand<3)
           {
               Instantiate(spike, obj.transform.position, Quaternion.identity, walls.transform);
           }
        }
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
           Instantiate(walls, spawnPosition, Quaternion.identity);
        }
    }

}
