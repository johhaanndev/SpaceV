using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishSong : MonoBehaviour
{
    private float time;
    public GameObject scoreHUD;
    public GameObject gameOverHUD;
    public GameObject youWinHUD;
    public Text finalScoreText;

    private ScoreManager scoreManager;

    private GameObject songObject;
    private GameObject playerObject;

    private float songTime;

    public bool isWin = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        playerObject = GameObject.Find("Player");
        time = 0.0f;
        songObject = GameObject.Find("Song");
        songTime = songObject.GetComponent<AudioSource>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= songTime && playerObject.GetComponent<ShipMovement>().GetAlive())
        {
            isWin = true;
            youWinHUD.SetActive(true);
            finalScoreText.text = $"Minerals collected: {scoreManager.GetMineralCount()}\n" +
                                  $"Total score: {scoreManager.GetScore() * (1 + scoreManager.GetMineralCount() / 100)}";

            playerObject.GetComponent<ShipMovement>().enabled = false;
            playerObject.GetComponent<ShipAbility>().enabled = false;
            scoreHUD.SetActive(false);
        }
    }
}
