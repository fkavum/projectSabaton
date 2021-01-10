using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playersound : MonoBehaviour
{
    public AudioSource playersource;
    public AudioClip betonclip;
    public AudioClip sandclip;
    public AudioClip ahsapclip;
    // Start is called before the first frame update
    void Start()
    {
        
        //playersource.clip = betonclip;
        //playersource.PlayOneShot(betonclip);
    }
    public void walksound()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Scene1") {
            playersource.clip = sandclip;
            playersource.PlayOneShot(sandclip);
        }
        if (scene.name == "Scene2")
        {
            playersource.clip = ahsapclip;
            playersource.PlayOneShot(ahsapclip);
        }
        if (scene.name == "Scene3")
        {
            playersource.clip = betonclip;
            playersource.PlayOneShot(betonclip);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
