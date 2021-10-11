using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject player;
    public GameObject clapParticles;
    public GameObject midParticles;
    public GameObject kickParticles;

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
    }

    public void DestroyClapAsteroid()
    {
        var particles = (GameObject)Instantiate(clapParticles, transform.position, transform.rotation);
        DestroyGO();
    }

    public void DestroyMidAsteroid()
    {
        var particles = (GameObject)Instantiate(midParticles, transform.position, transform.rotation);
        DestroyGO();
    }

    public void DestroyKickAsteroid()
    {
        var particles = (GameObject)Instantiate(kickParticles, transform.position, transform.rotation);
        DestroyGO();
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
        if (gameObject.CompareTag("ClapAsteroid"))
        {
            DestroyClapAsteroid();
        }

        if (gameObject.CompareTag("MidAsteroid"))
        {
            DestroyMidAsteroid();
        }

        if (collision.gameObject.CompareTag("ScreenBoundaries"))
        {
            DestroyGO();
        }
    }
}
