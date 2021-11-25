using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    [HideInInspector] public int score = 100;
    public ScoreManager scoreManager;
    public GameObject particles;

    private void Awake()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManager.AddMineral();
            var particlesInstance = (GameObject)Instantiate(particles, transform.position, transform.rotation);
            DestroyGO();
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
