using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject coin;
    Vector2 spawnPosition;
    float time;

    private void Awake()
    {
        spawnPosition.y = gameObject.transform.position.y;
    }
    void Start()
    {
        Invoke("TriggerCoroutines", 5); //Start spawning objects in 5 seconds
    }

    private void Update()
    {
        spawnPosition.x = Random.Range(-1.5f, 1.5f);
        time = Random.Range(8f, 17f); 
    }

    void TriggerCoroutines()
    {
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnCoins());
    }
    IEnumerator SpawnAsteroids()
    {
        //Changing condition is required
        while (true)
        {
            Instantiate(asteroid, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
   
    IEnumerator SpawnCoins()
    {
        //Changing condition is required
        while (true)
        {
            Instantiate(coin, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }


}
