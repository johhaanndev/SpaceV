using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CollectableSpawn : MonoBehaviour
{
    //public GameObject beatsChannel;
    //private bool beatsSpawned;

    public GameObject beatPrefab;
    public List<float> beatTimers;

    private GameObject songObject;

    private string directory = "Assets/Music/SongsData";
    private string songFolder;
    private string beatName;

    // Start is called before the first frame update
    void Start()
    {
        songObject = GameObject.Find("Song");
        songFolder = songObject.GetComponent<AudioSource>().clip.name;
        beatName = "Beats - " + songFolder;
        beatTimers = LoadDataFromJson();

        StartCoroutine(nameof(SpawnCollectable));
    }

    private IEnumerator SpawnCollectable()
    {
        yield return new WaitForSeconds(beatTimers[0]);
        var randomPoint = new Vector3(Random.Range(-7, 7),
                                      Random.Range(-4, 4),
                                      0f);

        var asteroid = (GameObject)Instantiate(beatPrefab, randomPoint, Quaternion.identity);

        for (int i = 1; i < beatTimers.Count; i++)
        {
            yield return new WaitForSeconds(beatTimers[i] - beatTimers[i - 1]);
            Debug.Log("Beat");
            randomPoint = new Vector3(Random.Range(-7, 7),
                                      Random.Range(-4, 4),
                                      0f);

            asteroid = (GameObject)Instantiate(beatPrefab, randomPoint, Quaternion.identity);

        }
    }

    private List<float> LoadDataFromJson()
    {
        string fileLocation = $"{directory}/{songFolder}/{beatName}.txt";

        ClipData clip = new ClipData();

        if (File.Exists(fileLocation))
        {
            Debug.Log("File exists");
            string json = File.ReadAllText(fileLocation);
            clip = JsonUtility.FromJson<ClipData>(json);
            return clip.times;
        }
        else
        {
            Debug.LogError("No such file found");
        }

        return new List<float>();
    }
}
