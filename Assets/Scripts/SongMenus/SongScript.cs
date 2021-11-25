using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SongScript : MonoBehaviour
{
    private GameObject sendSong;

    public string songName;
    public AudioSource trackSelected;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("MusicSelection"))
        {
            sendSong = GameObject.Find("Song");
        }
    }

    public void SelectSong()
    {
        songName = EventSystem.current.currentSelectedGameObject.name;
        var songObject = GameObject.Find($"Send {songName}");
        trackSelected = songObject.GetComponent<AudioSource>();
        sendSong.GetComponent<AudioSource>().clip = trackSelected.clip;
        var audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Stop();
        }
        GameObject.Find($"Send {songName}").GetComponent<AudioSource>().Play();
    }
}
