using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PercussionSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;

    private GameObject song;

    private GameObject kickChannel;
    public GameObject kickPrefab;
    private bool kickSpawned = false;

    private GameObject clapChannel;
    public GameObject clapPrefab;
    private bool clapSpawned = false;

    private GameObject midChannel;
    public GameObject midPrefab;
    private bool midSpawned = false;

    private GameObject beatChannel;

    // Start is called before the first frame update
    void Start()
    {
        song = GameObject.Find("Song");
        kickChannel = GameObject.Find("Kicks");
        clapChannel = GameObject.Find("Claps");
        midChannel = GameObject.Find("Mids");
        beatChannel = GameObject.Find("Beats");

        song.GetComponent<AudioSource>().Play();
        kickChannel.GetComponent<AudioSource>().Play();
        clapChannel.GetComponent<AudioSource>().Play();
        midChannel.GetComponent<AudioSource>().Play();
        beatChannel.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnClapAsteroids();
        SpawnKickAsteroids();
        SpawnMidAsteroids();
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
    private void SpawnMidAsteroids()
    {
        var midLoudness = midChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!midSpawned)
        {
            if (midLoudness >= 0.1f)
            {
                midSpawned = true;
                var randomPoint = Random.Range(0, spawnPoints.Count - 1);
                var asteroid = (GameObject)Instantiate(midPrefab, spawnPoints[randomPoint]);
            }
        }
        else
        {
            if (midLoudness < 0.1f) midSpawned = false;
        }
    }

}
