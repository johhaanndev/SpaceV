using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private ShipMovement ship;

    public GameObject scoreText;
    public GameObject mineralText;

    private float score = 0;
    private float mineralCount = 0;
    private float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Player").GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetAlive())
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= 0.1)
            {
                score++;
                timeCounter = 0;
            }
        }

        ShowScoreHUD();
        ShowMineralHUD();
    }

    private void ShowScoreHUD()
    {
        if (score < 10)
        {
            scoreText.GetComponent<Text>().text = $"Score: 00000{score}";
        }
        else if (score < 100)
        {
            scoreText.GetComponent<Text>().text = $"Score: 0000{score}";
        }
        else if (score < 1000)
        {
            scoreText.GetComponent<Text>().text = $"Score: 000{score}";
        }
        else if (score < 10000)
        {
            scoreText.GetComponent<Text>().text = $"Score: 00{score}";
        }
        else if (score < 100000)
        {
            scoreText.GetComponent<Text>().text = $"Score: 0{score}";
        }
        else if (score < 1000000)
        {
            scoreText.GetComponent<Text>().text = $"Score: {score}";
        }
    }

    private void ShowMineralHUD()
    {
        if (mineralCount < 10)
        {
            mineralText.GetComponent<Text>().text = $"Minerals: 00{mineralCount}";
        }
        else if (mineralCount < 100)
        {
            mineralText.GetComponent<Text>().text = $"Minerals: 0{mineralCount}";
        }
        else if (mineralCount < 1000)
        {
            mineralText.GetComponent<Text>().text = $"Minerals: {mineralCount}";
        }
    }

    public void AddMineral()
    {
        score += 100;
        mineralCount++;
    }

    public void SubstractMineral(int cost)
    {
        mineralCount -= cost;
    }

    public float GetMineralCount()
    {
        return mineralCount;
    }
}
