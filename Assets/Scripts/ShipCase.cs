using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Asteroid")
        {
            Debug.Log("Ship case hit");
        }
    }
}
