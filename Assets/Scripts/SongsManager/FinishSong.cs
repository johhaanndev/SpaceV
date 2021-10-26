using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishSong : MonoBehaviour
{
    private float time;
    public GameObject gameOverCanvas;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3 * 60 + 9)
        {
            gameOverCanvas.SetActive(true);
        }
    }
}
