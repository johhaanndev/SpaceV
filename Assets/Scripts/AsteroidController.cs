using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyerPoint"))
        {
            Debug.Log("Asteroid hit");
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit");
        }
    }
}
