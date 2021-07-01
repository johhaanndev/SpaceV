using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerPoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Asteroid")
        {
            Debug.Log("Asteroid Hit");
        }
    }
}
