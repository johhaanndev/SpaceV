using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject player;
    //public GameObject asteroidHalfPrefab;

    public float force;
    private Vector3 dir;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir = player.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        rb.AddForce(dir * force);

        Invoke(nameof(DestroyGO), 4f);
    }

    private void Update()
    {

    }

    //public void AsteroidDestroy()
    //{
    //    if (gameObject.name == "Asteroid")
    //    {
    //        var asteroidHalf = (GameObject)Instantiate(asteroidHalfPrefab);
    //    }
    //}

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}