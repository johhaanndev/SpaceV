using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log($"{score} points");
            DestroyGO();
        }
    }

    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
