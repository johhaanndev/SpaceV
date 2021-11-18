using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongReadyToSend : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void JumpToGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
        GetComponent<AudioSource>().Play();
        Debug.Log(GetComponent<AudioSource>().clip.length);
    }
}
