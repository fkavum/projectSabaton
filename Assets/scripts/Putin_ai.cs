using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putin_ai : MonoBehaviour
{
    public GameObject putinmodel;
    // Start is called before the first frame update
    public float turnspeed = 0.1f;
    public float mspeed = 0.5f;
    float startX = 0f;
    Vector3 startPosition;
    
    public void turn()
    {
        //transform.RotateAround(transform.position, Vector3.up, 90*Time.deltaTime);
        //transform.Rotate(new Vector3(0,90,0)*turnspeed);
        //InvokeRepeating("turner", 1, 1);
        while (transform.eulerAngles.y < 270)
        {
            transform.Rotate(Vector3.up * Time.deltaTime*turnspeed);
        }
        Debug.Log("turned");
        Vector3 startPosition = transform.position;
        //Invoke("walk", 1f);

        
        


    }
    public void walk()
    {
        
        //transform.Translate(Vector3.forward * Time.deltaTime);
        //var pos = transform.position;
        //var newX = startX + 100 * Mathf.Sin(Time.time * mspeed);
        //var newX = startX + 100 * (Time.time * mspeed);
        //transform.position = new Vector3(newX, pos.y, pos.z);
        //transform.Translate(0, 0, 1.5f*mspeed*Time.deltaTime);    
        transform.position = Vector3.Lerp(startPosition, new Vector3 (1.5f,0,0)+transform.forward, mspeed*Time.deltaTime);
        Debug.Log("Walked");
    }

    void Start()
    {
        Vector3 startPosition = transform.position;
        //turn();
        //putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }

    // Update is called once per frame
    void Update()
    {
        //var pos = transform.position;
        //var newX = startX + 700f * Mathf.Sin(Time.time * mspeed);
        //transform.position = new Vector3(newX, pos.y, pos.z);
        //putinmodel.GetComponent<Animator>().Play("Putin_sit");
    }
}
