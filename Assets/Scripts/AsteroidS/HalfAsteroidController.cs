using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfAsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float force;
    public Vector3 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Invoke(nameof(DestroyAsteroid), 4f);
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
    }
}
