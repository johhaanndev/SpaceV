using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    [HideInInspector]
    public GameObject songObject;

    public GameObject imageBackground;

    // Start is called before the first frame update
    void Start()
    {
        songObject = GameObject.Find("Song");
        if (!songObject.GetComponent<AudioSource>().clip.name.Equals("TUTORIAL - Show Me - LiQWYD"))
        {
            Destroy(gameObject);
        }
        else
        {
            imageBackground.SetActive(false);
        }
    }
}
