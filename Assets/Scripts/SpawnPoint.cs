using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private GameObject spawner;
    private PercussionSpawner percussionSpawner;
    private MelodySpawner softMelodySpawner;
    private MelodySpawner dropMelodySpawner;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject.name.StartsWith("SpawnPoint"))
        {
            spawner = GameObject.Find("PercussionSpawners");
            percussionSpawner = spawner.GetComponent<PercussionSpawner>();

            percussionSpawner.spawnPoints.Add(this.gameObject.transform);
        }

        if (gameObject.name.StartsWith("SoftMelodySpawnPoint"))
        {
            spawner = GameObject.Find("MelodySpawners");
            softMelodySpawner = spawner.GetComponent<MelodySpawner>();

            softMelodySpawner.softSpawnPoints.Add(this.gameObject.transform);
        }

        if (gameObject.name.StartsWith("DropMelodySpawnPoint"))
        {
            spawner = GameObject.Find("MelodySpawners");
            dropMelodySpawner = spawner.GetComponent<MelodySpawner>();

            dropMelodySpawner.dropSpawnPoints.Add(this.gameObject.transform);
        }


    }
}
