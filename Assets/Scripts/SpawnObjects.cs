using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;
    GameObject objectToSpawn;
    Vector2 spawnPosition;
    float time;

    private void Awake()
    {
        spawnPosition.y = gameObject.transform.position.y;
    }
    void Start()
    {
        Invoke("TriggerCoroutine", 5); //Start spawning objects in 5 seconds
    }

    private void Update()
    {
        spawnPosition.x = Random.Range(-1.5f, 1.5f);
        time = Random.Range(3f, 9f);
    }

    void TriggerCoroutine()
    {
        StartCoroutine(SpawnRandomObjects());
    }
    IEnumerator SpawnRandomObjects()
    {
        while (Time.timeScale > 0)
        {
            if(Random.Range(0, 100) < 45)
            {
                objectToSpawn = objects[0];
            }
            else if (Random.Range(0, 100) < 90)
            {
                objectToSpawn = objects[1];
            }
            else
            {
                objectToSpawn = objects[2];
            }

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

}
