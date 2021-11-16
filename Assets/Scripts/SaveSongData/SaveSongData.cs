using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSongData : MonoBehaviour
{
    public ClipData clipData;
    public GameObject songAudio;
    private bool isSpawned = false;
    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= GetComponent<AudioSource>().clip.length)
            AddTimeToClipData();
        else
        {
            SaveManager.Save(clipData);
            Debug.Log(clipData.times);
        }
    }

    private void AddTimeToClipData()
    {
        var loud = songAudio.GetComponent<AudioFrecuency>().clipLoudness;
        if (!isSpawned)
        {
            if (loud >= 0.1f)
            {
                Debug.Log("Beat detected");
                isSpawned = true;
                clipData.times.Add(timer);
                Debug.Log(clipData.times);
            }
        }
        else
        {
            if (loud < 0.1f) isSpawned = false;
        }
    }
}
