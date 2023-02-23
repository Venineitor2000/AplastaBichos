using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Morir", 0.5f);
    }

    void Morir()
    {
        Destroy(gameObject);
    }
}
