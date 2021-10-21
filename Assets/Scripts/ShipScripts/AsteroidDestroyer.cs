using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyGO), 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + (Time.deltaTime * 70),
                                                      gameObject.transform.localScale.y + (Time.deltaTime * 70),
                                                      0);
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ClapAsteroid"))
            collision.gameObject.GetComponent<AsteroidController>().DestroyClapAsteroid();
        if (collision.gameObject.CompareTag("MidAsteroid"))
            collision.gameObject.GetComponent<AsteroidController>().DestroyMidAsteroid();
        if (collision.gameObject.CompareTag("KickAsteroid"))
            collision.gameObject.GetComponent<AsteroidController>().DestroyKickAsteroid();
    }
}
