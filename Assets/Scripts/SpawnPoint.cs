using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject spawner;
    private PercussionSpawner percussionSpawner;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.name.StartsWith("SpawnPoint"))
        {
            spawner = GameObject.Find("PercussionSpawners");
            percussionSpawner = spawner.GetComponent<PercussionSpawner>();

            percussionSpawner.spawnPoints.Add(this.gameObject.transform);
        }
    }
}
