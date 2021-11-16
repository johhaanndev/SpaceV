using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishSong : MonoBehaviour
{
    private float time;
    public GameObject gameOverCanvas;

    private GameObject songObject;

    private float songTime;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        songObject = GameObject.Find("Song");
        songTime = songObject.GetComponent<AudioSource>().clip.length - 10;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= songTime)
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
