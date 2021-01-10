using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tachanka : MonoBehaviour
{
    public AudioSource Tachankasource;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tachankasource.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tachankasource.enabled = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
