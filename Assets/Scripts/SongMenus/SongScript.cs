using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    private GameObject sendSong;

    public string songName;
    public AudioClip trackSelected;
    public AudioSource trackSource;

    public GameObject topScoreHUD;
    private float topScore = 0;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("MusicSelection"))
        {
            sendSong = GameObject.Find("Song");
        }
        trackSource = GetComponent<AudioSource>();
    }

    public void SelectSong()
    {
        songName = EventSystem.current.currentSelectedGameObject.name;
        var songObject = GameObject.Find($"Send {songName}");
        
        // Find mp3 in folders
        trackSelected = Resources.Load($"Songs/{songName}") as AudioClip;
        trackSource.clip = trackSelected;
        // trackSelected = songObject.GetComponent<AudioSource>();
        sendSong.GetComponent<AudioSource>().clip = trackSelected;
        var audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Stop();
        }
        trackSource.Play();

        topScoreHUD.SetActive(true);
        topScoreHUD.GetComponentInChildren<Text>().text = $"{songName}\n\nTop score: {topScore}";
    }

    public void SetTopScore(float score)
    {
        Debug.Log("Setting score");
        if (score > topScore)
            topScore = score;
    }
}
