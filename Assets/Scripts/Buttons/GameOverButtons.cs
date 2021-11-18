using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameObject.Find("Song").GetComponent<AudioSource>().Play();
    }

    public void MainMenuButton()
    {
        Destroy(GameObject.Find("Song"));
        SceneManager.LoadScene("MusicSelection");
    }
}
