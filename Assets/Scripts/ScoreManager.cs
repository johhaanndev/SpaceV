using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private ShipMovement ship;
    private ShipAbility shipAbility;

    public GameObject scoreText;
    public GameObject mineralText;

    private float score = 0;
    private float mineralCount = 0;
    private float timeCounter = 0;

    public Image mineralBar;
    private float abilityCost;

    private TopScoreTransferScript topScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("Player").GetComponent<ShipMovement>();
        shipAbility = GameObject.Find("Player").GetComponent<ShipAbility>();
        abilityCost = shipAbility.cost;

        topScoreScript = GameObject.Find("TopScoreTransfer").GetComponent<TopScoreTransferScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ship.GetAlive())
        {
            timeCounter += Time.deltaTime;
            if (timeCounter >= 0.1 && !GameObject.Find("ScoreManager").GetComponent<FinishSong>().isWin)
            {
                score++;
                timeCounter = 0;
            }
        }
        else
        {
            topScoreScript.SetFinalScore(score, GameObject.Find("Song").GetComponent<AudioSource>().clip.name);
        }
        mineralBar.fillAmount = mineralCount / abilityCost;
        UpdateScoreHUD();
        UpdateMineralHUD();
    }

    private void UpdateScoreHUD()
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

    private void UpdateMineralHUD()
    {
        if (mineralCount < 10)
        {
            mineralText.GetComponent<Text>().text = $"00{mineralCount}";
        }
        else if (mineralCount < 100)
        {
            mineralText.GetComponent<Text>().text = $"0{mineralCount}";
        }
        else if (mineralCount < 1000)
        {
            mineralText.GetComponent<Text>().text = $"{mineralCount}";
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

    public float GetScore()
    {
        return score;
    }
}
