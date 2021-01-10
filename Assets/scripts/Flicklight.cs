using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicklight : MonoBehaviour
{
    public Material red;
    public GameObject flicklight;
    public bool Switch = true;
    void Start()
    {

        red = flicklight.GetComponent<Renderer>().material;

        StartCoroutine("cycle");
        Debug.Log("started.");
    }
    IEnumerator cycle()
    {
        while (true)
        {
            if (Switch == true)
            {
                red.EnableKeyword("_EMISSION");
                yield return new WaitForSeconds(2);   //Wait
                Switch = false;
            }
            if (Switch == false)
            {
                Switch = true;
                red.DisableKeyword("_EMISSION");
                yield return new WaitForSeconds(2);
            }
        }
    }

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
