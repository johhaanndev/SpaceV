using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodySpawner : MonoBehaviour
{
    public List<Transform> softSpawnPoints;
    public List<Transform> dropSpawnPoints;

    public GameObject softMelodyChannel;
    public GameObject softMelodyPrefab;
    private bool softMelodySpawned = false;

    public GameObject dropMelodyChannel;
    public GameObject dropMelodyPrefab;
    private bool dropMelodySpawned = false;

    public float cooldown = 1f;
    private float timeCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnSoftAsteroids();
        SpawnDropAsteroids();
    }

    private void SpawnSoftAsteroids()
    {
        var softLoudness = softMelodyChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!softMelodySpawned)
        {
            if (softLoudness >= 0.1f)
            {
                // Spawn
            }
        }
        else
        {
            if (softLoudness < 0.1f) softMelodySpawned = false;
        }
    }

    private void SpawnDropAsteroids()
    {
        var dropLoudness = dropMelodyChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!dropMelodySpawned)
        {
            if (dropLoudness >= 0.1f)
            {
                // Spawn
            }
        }
        else
        {
            if (dropLoudness < 0.1f) dropMelodySpawned = false;
        }
    }
}
