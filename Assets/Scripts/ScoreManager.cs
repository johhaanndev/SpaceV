using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject scoreText;

    private float score = 0;
    private float timeCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 0.1)
        {
            score++;
            timeCounter = 0;
        }
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
}
