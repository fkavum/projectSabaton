using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putin_ai : MonoBehaviour
{
    public GameObject putinmodel;
    // Start is called before the first frame update
    void Start()
    {
        putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }

    // Update is called once per frame
    void Update()
    {
        //putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }
}
