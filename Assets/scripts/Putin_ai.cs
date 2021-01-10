using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putin_ai : MonoBehaviour
{
    public GameObject putinmodel;
    // Start is called before the first frame update
    public float turnspeed = 1f;
    public void turn()
    {
        //transform.RotateAround(transform.position, Vector3.up, 90*Time.deltaTime);
        //transform.Rotate(new Vector3(0,90,0)*turnspeed);
        //InvokeRepeating("turner", 1, 1);
        while (transform.eulerAngles.y < 270)
        {
            transform.Rotate(Vector3.up * 1f * Time.deltaTime);
        }
        Debug.Log("turned");
        void turner () { 
            if (transform.eulerAngles.y < 270)
            {
                transform.Rotate(Vector3.up * 1 * Time.deltaTime);
            } 
        }
        


    }
    void Start()
    {
        //turn();
        //putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }

    // Update is called once per frame
    void Update()
    {
        //
        //turn();
        //putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }
}
