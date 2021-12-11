using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopScoreTransferScript : MonoBehaviour
{
    private float finalScore = 0.0f;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MusicSelection"))
        {
            Debug.Log("in MenuSelection");
            var scoreTarget = GameObject.Find("Menu canvas").GetComponent<SongScript>();
            scoreTarget.SetTopScore(finalScore);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not in menu");
        }
    }

    public void SetFinalScore(float score)
    {
        Debug.Log("Setting final score");
        finalScore = score;
    }
}
