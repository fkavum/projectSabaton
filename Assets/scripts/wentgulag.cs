using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wentgulag : MonoBehaviour
{
    public GameObject gameovertext; 
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameovertext.SetActive(true);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
