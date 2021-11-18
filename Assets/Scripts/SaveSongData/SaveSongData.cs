using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSongData : MonoBehaviour
{
    public GameObject mainSong;

    public ClipData clipData;
    public GameObject channelAudio;
    private bool isSpawned = false;
    private float timer = 0.0f;

    public static string kicksFilename;

    private void Awake()
    {
        kicksFilename = $"{mainSong.GetComponent<AudioSource>().clip.name}.txt";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= GetComponent<AudioSource>().clip.length)
        {
            AddTimeToClipData();
        }
        else
        {
            SaveManager.Save(clipData);
            Debug.Log(clipData.times);
        }
    }

    private void AddTimeToClipData()
    {
        var loud = channelAudio.GetComponent<AudioFrecuency>().clipLoudness;
        if (!isSpawned)
        {
            if (loud >= 0.1f)
            {
                isSpawned = true;
                clipData.times.Add(timer);
                Debug.Log(timer);
            }
        }
        else
        {
            if (loud < 0.1f) isSpawned = false;
        }
    }

    

    //public static void SaveKicks(ClipData clip)
    //{
    //    Debug.Log($"Saved {kicksFilename}");
    //    string dir = Application.persistentDataPath + directory;

    //    if (!Directory.Exists(dir))
    //        Directory.CreateDirectory(dir);

    //    string json = JsonUtility.ToJson(clip);
    //    File.WriteAllText(dir + kicksFilename, json);
    //}

    //public static void SaveClaps(ClipData clip)
    //{
    //    Debug.Log($"Saved {clapsFilename}");
    //    string dir = Application.persistentDataPath + directory;

    //    if (!Directory.Exists(dir))
    //        Directory.CreateDirectory(dir);

    //    string json = JsonUtility.ToJson(clip);
    //    File.WriteAllText(dir + clapsFilename, json);
    //}

    //public static void SaveMids(ClipData clip)
    //{
    //    Debug.Log($"Saved {midsFilename}");
    //    string dir = Application.persistentDataPath + directory;

    //    if (!Directory.Exists(dir))
    //        Directory.CreateDirectory(dir);

    //    string json = JsonUtility.ToJson(clip);
    //    File.WriteAllText(dir + midsFilename, json);
    //}

    //public static void SaveBeats(ClipData clip)
    //{
    //    Debug.Log($"Saved {beatsFilename}");
    //    string dir = Application.persistentDataPath + directory;

    //    if (!Directory.Exists(dir))
    //        Directory.CreateDirectory(dir);

    //    string json = JsonUtility.ToJson(clip);
    //    File.WriteAllText(dir + beatsFilename, json);
    //}
}
