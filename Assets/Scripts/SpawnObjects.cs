using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    private GameObject objectToSpawn;
    private Vector2 spawnPosition;
    private float time;

    public GameObject[] objects;

    private void Awake()
    {
        spawnPosition.y = gameObject.transform.position.y;
    }

    private void Start()
    {
        Invoke("TriggerCoroutine", 5); //Start spawning objects in 5 seconds
    }

    private void Update()
    {
        spawnPosition.x = Random.Range(-1.5f, 1.5f);
        time = Random.Range(3f, 9f);
    }

    private void TriggerCoroutine()
    {
        StartCoroutine(SpawnRandomObjects());
    }

    private IEnumerator SpawnRandomObjects()
    {
        while (Time.timeScale > 0)
        {
            if(Random.Range(0, 100) < 45)
            {
                objectToSpawn = objects[0]; //Coin
            }
            else if (Random.Range(0, 100) < 80)
            {
                objectToSpawn = objects[1]; //Asteroid
            }
            else if (Random.Range(0, 100) < 90)
            {
                objectToSpawn = objects[2]; //Heal
            }
            else
            {
                objectToSpawn = objects[3]; //Shield
            }

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

}
