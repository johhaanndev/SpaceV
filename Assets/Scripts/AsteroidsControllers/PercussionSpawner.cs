using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PercussionSpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;

    //private GameObject kickChannel;
    //private bool kickSpawned = false;
    //private GameObject clapChannel;
    //private bool clapSpawned = false;
    //private GameObject midChannel;
    //private bool midSpawned = false;

    private GameObject song;

    public List<float> kickTimer;
    public List<float> clapTimer;
    public List<float> midTimer;

    public GameObject kickPrefab;
    public GameObject clapPrefab;
    public GameObject midPrefab;

    private string directory;
    private string songFolder;
    private string kickName;
    private string clapName;
    private string midName;

    // Start is called before the first frame update
    void Start()
    {
        directory = $"{Application.persistentDataPath}/SaveData/";
        song = GameObject.Find("Song");
        songFolder = song.GetComponent<AudioSource>().clip.name;
        kickName = "Kicks - " + songFolder;
        clapName = "Claps - " + songFolder;
        midName = "Mids - " + songFolder;

        kickTimer = LoadKickDataFromJson();
        clapTimer = LoadClapDataFromJson();
        midTimer = LoadMidDataFromJson();

        StartCoroutine(nameof(SpawnKicks));
        StartCoroutine(nameof(SpawnClaps));
        StartCoroutine(nameof(SpawnMids));

        //kickChannel = GameObject.Find("Kicks");
        //clapChannel = GameObject.Find("Claps");
        //midChannel = GameObject.Find("Mids");

        //song.GetComponent<AudioSource>().Play();
        //kickChannel.GetComponent<AudioSource>().Play();
        //clapChannel.GetComponent<AudioSource>().Play();
        //midChannel.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnClapAsteroids();
        //SpawnKickAsteroids();
        //SpawnMidAsteroids();
    }

    private List<float> LoadKickDataFromJson()
    {
        string fileLocation = $"{directory}/{songFolder}/{kickName}.txt";

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
            Debug.LogError($"No such file found: {fileLocation}");
        }

        return new List<float>();
    }

    private List<float> LoadClapDataFromJson()
    {
        string fileLocation = $"{directory}/{songFolder}/{clapName}.txt";

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
            Debug.LogError($"No such file found: {fileLocation}");
        }

        return new List<float>();
    }

    private List<float> LoadMidDataFromJson()
    {
        string fileLocation = $"{directory}/{songFolder}/{midName}.txt";

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
            Debug.LogError($"No such file found: {fileLocation}");
        }

        return new List<float>();
    }

    private IEnumerator SpawnKicks()
    {
        yield return new WaitForSeconds(kickTimer[0]);
        var randomPoint = Random.Range(0, spawnPoints.Count - 1);
        var asteroid = (GameObject)Instantiate(kickPrefab, spawnPoints[randomPoint]);

        for (int i = 1; i < kickTimer.Count; i++)
        {
            yield return new WaitForSeconds(kickTimer[i] - kickTimer[i - 1]);
            randomPoint = Random.Range(0, spawnPoints.Count - 1);
            asteroid = (GameObject)Instantiate(kickPrefab, spawnPoints[randomPoint]);
        }
    }

    private IEnumerator SpawnClaps()
    {
        yield return new WaitForSeconds(clapTimer[0]);
        var randomPoint = Random.Range(0, spawnPoints.Count - 1);
        var asteroid = (GameObject)Instantiate(clapPrefab, spawnPoints[randomPoint]);

        for (int i = 1; i < clapTimer.Count; i++)
        {
            yield return new WaitForSeconds(clapTimer[i] - clapTimer[i - 1]);
            randomPoint = Random.Range(0, spawnPoints.Count - 1);
            asteroid = (GameObject)Instantiate(clapPrefab, spawnPoints[randomPoint]);
        }
    }

    private IEnumerator SpawnMids()
    {
        yield return new WaitForSeconds(midTimer[0]);
        var randomPoint = Random.Range(0, spawnPoints.Count - 1);
        var asteroid = (GameObject)Instantiate(midPrefab, spawnPoints[randomPoint]);

        for (int i = 1; i < midTimer.Count; i++)
        {
            yield return new WaitForSeconds(midTimer[i] - midTimer[i - 1]);
            randomPoint = Random.Range(0, spawnPoints.Count - 1);
            asteroid = (GameObject)Instantiate(midPrefab, spawnPoints[randomPoint]);
        }
    }

    //private void SpawnClapAsteroids()
    //{
    //    var clapLoudness = clapChannel.GetComponent<AudioFrecuency>().clipLoudness;

    //    if (!clapSpawned)
    //    {
    //        if (clapLoudness >= 0.1f)
    //        {
    //            clapSpawned = true;
    //            var randomPoint = Random.Range(0, spawnPoints.Count - 1);
    //            var asteroid = (GameObject)Instantiate(clapPrefab, spawnPoints[randomPoint]);
    //        }
    //    }
    //    else
    //    {
    //        if (clapLoudness < 0.1f) clapSpawned = false;
    //    }
    //}

    //private void SpawnKickAsteroids()
    //{
    //    var kickLoudness = kickChannel.GetComponent<AudioFrecuency>().clipLoudness;

    //    if (!kickSpawned)
    //    {
    //        if (kickLoudness >= 0.1f)
    //        {
    //            kickSpawned = true;
    //            var randomPoint = Random.Range(0, spawnPoints.Count - 1);
    //            var asteroid = (GameObject)Instantiate(kickPrefab, spawnPoints[randomPoint]);
    //        }
    //    }
    //    else
    //    {
    //        if (kickLoudness < 0.1f) kickSpawned = false;
    //    }
    //}
    //private void SpawnMidAsteroids()
    //{
    //    var midLoudness = midChannel.GetComponent<AudioFrecuency>().clipLoudness;

    //    if (!midSpawned)
    //    {
    //        if (midLoudness >= 0.1f)
    //        {
    //            midSpawned = true;
    //            var randomPoint = Random.Range(0, spawnPoints.Count - 1);
    //            var asteroid = (GameObject)Instantiate(midPrefab, spawnPoints[randomPoint]);
    //        }
    //    }
    //    else
    //    {
    //        if (midLoudness < 0.1f) midSpawned = false;
    //    }
    //}
}
