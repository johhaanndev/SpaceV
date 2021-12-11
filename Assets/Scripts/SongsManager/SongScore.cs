using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongScore : MonoBehaviour
{
    public int maxScore;

    public Text maxScoreText; 
    
    public void SetScore(int score)
    {
        if (score > maxScore)
        {
            maxScore = score;
        }
    }
}
