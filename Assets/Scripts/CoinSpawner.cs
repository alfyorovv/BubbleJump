using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    Vector2 spawnPosition;
    int counter = 0;

    private void Start()
    {
        spawnPosition.y = gameObject.transform.position.y;
    }

    void Update()
    {
        counter++;
        if (counter == 1000)
        {
            counter = 0;
            spawnPosition.x = Random.Range(-1.5f, 1.5f);
            Instantiate(coin, spawnPosition, Quaternion.identity);
        }
    }
}
