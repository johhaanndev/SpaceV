using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyGO), 1f);
    }

    private void DestroyGO()
    {
        Destroy(gameObject);
    }
}
