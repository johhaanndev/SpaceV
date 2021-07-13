using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawn : MonoBehaviour
{
    public GameObject beatsChannel;
    public GameObject beatPrefab;
    private bool beatsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnCollectable();
    }

    private void SpawnCollectable()
    {
        var beatsLoudness = beatsChannel.GetComponent<AudioFrecuency>().clipLoudness;

        if (!beatsSpawned)
        {
            if (beatsLoudness >= 0.1f)
            {
                beatsSpawned = true;
                var randomPoint = new Vector3(Random.Range(-7, 7),
                                              Random.Range(-4, 4),
                                              0f);

                var asteroid = (GameObject)Instantiate(beatPrefab, randomPoint, Quaternion.identity);
            }
        }
        else
        {
            if (beatsLoudness < 0.1f) beatsSpawned = false;
        }
    }
}
