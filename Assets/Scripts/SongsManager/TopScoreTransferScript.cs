using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopScoreTransferScript : MonoBehaviour
{
    private float finalScore = 0.0f;
    private string songName;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MusicSelection"))
        {
            var songToSendScore = GameObject.Find("SongList");
            songToSendScore.GetComponent<SongsHighScore>().SetHighScoreToSong(songName, finalScore);
            Destroy(gameObject);
        }
        else
        {
            songName = GameObject.Find("Song").GetComponent<AudioSource>().clip.name;
        }
    }

    public void SetFinalScore(float score, string songToSend)
    {
        songName = songToSend;
        finalScore = score;
    }
}
