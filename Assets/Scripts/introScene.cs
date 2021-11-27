using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introScene : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MusicSelection");
    }
}
