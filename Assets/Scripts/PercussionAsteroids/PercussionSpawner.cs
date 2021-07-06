using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercussionSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;

    public GameObject kickChannel;
    public GameObject kickPrefab;
    private bool kickSpawned = false;

    public GameObject clapChannel;
    public GameObject clapPrefab;
    private bool clapSpawned = false;

    public float cooldown = 1f;    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnClapAsteroids();
        SpawnKickAsteroids();
    }

    private void SpawnClapAsteroids()
    {
        var clapLoudness = clapChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!clapSpawned)
        {
            if (clapLoudness >= 0.1f)
            {
                clapSpawned = true;
                var randomPoint = Random.Range(0, spawnPoints.Count - 1);
                var asteroid = (GameObject)Instantiate(clapPrefab, spawnPoints[randomPoint]);
            }
        }
        else
        {
            if (clapLoudness < 0.1f) clapSpawned = false;
        }
    }

    private void SpawnKickAsteroids()
    {
        var kickLoudness = kickChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!kickSpawned)
        {
            if (kickLoudness >= 0.1f)
            {
                kickSpawned = true;
                var randomPoint = Random.Range(0, spawnPoints.Count - 1);
                var asteroid = (GameObject)Instantiate(kickPrefab, spawnPoints[randomPoint]);
            }
        }
        else
        {
            if (kickLoudness < 0.1f) kickSpawned = false;
        }
    }

    //timeCounter += Time.deltaTime;
    //    if (timeCounter >= cooldown)
    //    {
    //        timeCounter = 0f;
    //        var randomPoint = Random.RandomRange(0, spawnPoints.Length - 1);
    //var asteroid = (GameObject)Instantiate(asteroids, spawnPoints[randomPoint]);
}
