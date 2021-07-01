using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject asteroids;
    private float timeCounter = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1.0f)
        {
            timeCounter = 0f;
            var randomPoint = Random.RandomRange(0, spawnPoints.Length - 1);
            var asteroid = (GameObject)Instantiate(asteroids, spawnPoints[randomPoint]);
        }
    }
}
