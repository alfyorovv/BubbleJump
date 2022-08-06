
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject walls;
    public GameObject spawnPoint;
    Vector2 spawnPosition;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        spawnPosition = spawnPoint.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Invisible");
        Instantiate(walls, spawnPosition, Quaternion.identity);
    }
}
