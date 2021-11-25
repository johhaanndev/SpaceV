using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public int angleOffset = 270;
    public float movForce = 5f;

    private Rigidbody2D rb;

    private bool alive = true;

    public GameObject deathParticles;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    public AudioSource musicStop;
    public AudioSource gameOverSong;
    private AudioSource currentSong;

    public GameObject gameOverCanvas;

    public GameObject cameraShake;
    public float shakeDuration;
    public float shakeMagnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        polygonCollider = gameObject.GetComponentInChildren<PolygonCollider2D>();
        currentSong = GameObject.Find("Song").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (alive)
            MoveControls();
    }

    private void MoveControls()
    {
        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Z))
        {
            rb.AddForce((dir - transform.position) * Time.deltaTime * movForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Asteroid"))
        {
            alive = false;
            GameOver();
        }
    }

    private void GameOver()
    {
        StartCoroutine(cameraShake.GetComponent<CameraShake>().Shake(shakeDuration, shakeMagnitude));
        gameOverCanvas.SetActive(true);
        var particles = (GameObject)Instantiate(deathParticles, transform.position, transform.rotation);
        spriteRenderer.enabled = false;
        polygonCollider.enabled = false;
        musicStop.Play();
        gameOverSong.Play();
        currentSong.Stop();
    }

    public bool GetAlive()
    {
        return alive;
    }
}
