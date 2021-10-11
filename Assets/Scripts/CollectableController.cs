using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [HideInInspector] public int score = 100;
    public ScoreManager scoreCanvas;

    private void Awake()
    {
        scoreCanvas = GameObject.Find("ScoreCanvas").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreCanvas.AddMineral();
            DestroyGO();
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
