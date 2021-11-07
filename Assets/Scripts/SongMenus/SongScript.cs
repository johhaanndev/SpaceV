using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SongScript : MonoBehaviour
{
    private GameObject sendSong;
    private GameObject sendKicks;
    private GameObject sendClaps;
    private GameObject sendMids;
    private GameObject sendBeats;

    public string songName;
    public AudioSource trackSelected;
    public AudioSource kickSelected;
    public AudioSource clapsSelected;
    public AudioSource midsSelected;
    public AudioSource beatsSelected;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("MusicSelection"))
        {
            sendSong = GameObject.Find("Song");
            sendKicks = GameObject.Find("Kicks");
            sendClaps = GameObject.Find("Claps");
            sendMids = GameObject.Find("Mids");
            sendBeats = GameObject.Find("Beats");
        }
    }

    public void SelectSong()
    {
        songName = EventSystem.current.currentSelectedGameObject.name;
        var songObject = GameObject.Find($"Send {songName}");
        trackSelected = songObject.GetComponent<AudioSource>();
        sendSong.GetComponent<AudioSource>().clip = trackSelected.clip;

        kickSelected = songObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        sendKicks.GetComponent<AudioSource>().clip = kickSelected.clip;

        clapsSelected = songObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
        sendClaps.GetComponent<AudioSource>().clip = clapsSelected.clip;

        midsSelected = songObject.transform.GetChild(2).gameObject.GetComponent<AudioSource>();
        sendMids.GetComponent<AudioSource>().clip = midsSelected.clip;

        beatsSelected = songObject.transform.GetChild(3).gameObject.GetComponent<AudioSource>();
        sendBeats.GetComponent<AudioSource>().clip = beatsSelected.clip;
    }
}
