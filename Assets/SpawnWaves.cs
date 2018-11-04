using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnWaves : MonoBehaviour {

    public GameObject[] spawnLocations;
    public GameObject enemy;

    public float timeUntilSpawn;
    float timeUntilSpawnCounter;

    public Text Counter;
	// Use this for initialization
	void Start ()
    {
        timeUntilSpawnCounter = timeUntilSpawn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Counter.text = "Time Until Next Wave: " + timeUntilSpawnCounter.ToString("F2");

        timeUntilSpawnCounter -= Time.deltaTime;

        if(timeUntilSpawnCounter <= 0)
        {
            for (int i = 0; i < 2; i++)
            {
                if (FindObjectsOfType<Enemy>().Length < 10)
                {
                    int location = Random.Range(0, 4);
                    Instantiate(enemy, spawnLocations[location].transform.position, spawnLocations[location].transform.rotation);
                }
            }
            timeUntilSpawnCounter = timeUntilSpawn;
        }
	}
}
