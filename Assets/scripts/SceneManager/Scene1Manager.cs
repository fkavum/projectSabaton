using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Manager : MonoBehaviour
{
    public static Scene1Manager instance;

    public AudioSource source;
    public AudioClip putinWelcome;
    public AudioClip secondSound;
    public AudioClip letter;

    public Transform post;
    public bool isPutinTalked = false;
    public bool isLevelEnd = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source.clip = putinWelcome;
        source.loop = false;
        source.Play();
    }


    public void PlayerHasBottle()
    {
        source.clip = secondSound;
        source.loop = false;
        source.Play();
    }
    public void PutinHasBottle()
    {
        post.gameObject.SetActive(true);
        source.clip = letter;
        source.loop = false;
        source.Play();
        isLevelEnd = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && source.clip == letter)
        {
            post.gameObject.SetActive(false);
            source.Stop();
        }
    }

}
