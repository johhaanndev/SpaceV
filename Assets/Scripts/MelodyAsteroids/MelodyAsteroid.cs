using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MelodyAsteroid : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject player;

    public float force;
    private Vector3 dir;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = new Vector3(0f, -1f, 0f);
        rb.AddForce(dir * force);

        //Invoke(nameof(DestroyGO), 4f);
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }

    public void HitByPlayer()
    {
        DestroyGO();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ScreenBoundaries"))
        {
            DestroyGO();
        }
    }
}
