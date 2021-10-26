using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [HideInInspector] public int score = 100;
    public ScoreManager scoreCanvas;
    public GameObject particles;

    private void Awake()
    {
        scoreCanvas = GameObject.Find("ScoreCanvas").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreCanvas.AddMineral();
            var particlesInstance = (GameObject)Instantiate(particles, transform.position, transform.rotation);
            DestroyGO();
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
