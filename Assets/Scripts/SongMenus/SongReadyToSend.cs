using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongReadyToSend : MonoBehaviour
{
    public GameObject chooseSongText;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void JumpToGamePlayScene()
    {
        if (GetComponent<AudioSource>().clip == null)
        {
            chooseSongText.SetActive(true);
            Invoke(nameof(DeactivateWarningText), 1.75f);
        }
        else
        {
            SceneManager.LoadScene("GamePlayScene");
            GetComponent<AudioSource>().Play();
        }
    }

    public void DeactivateWarningText()
    {
        chooseSongText.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
