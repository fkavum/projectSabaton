/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    public int forceConst = 10;
    private bool canJump;
    private Rigidbody selfRigidbody;
    private float timepassed;
    private float jumpcooldown = 1.5f;
    public GameObject playermodel;
    private bool idle;
    private bool jumping;
    private bool running;
    private bool crouching;
    private Vector3 lastposition;



    // Use this for initialization
    void Start()
    {
        lastposition = playermodel.transform.position;  
        idle = true;
        jumping = false;
        running = false;
        crouching = false;
        timepassed = -jumpcooldown;
        selfRigidbody = GetComponent<Rigidbody>();
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (canJump)
        {
            canJump = false;
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);
        if ((Input.GetKey(KeyCode.W) && (jumping ==false )&&(running == false)))
        {
            playermodel.GetComponent<Animator>().Play("Run");
            running = true;
            Invoke("norun", 0.75f);

            //Invoke("noanimation(running)", 1.5f);
        }
        else
        {
            
            //running = false;
        }
        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (Time.time - timepassed > jumpcooldown))
        {
            timepassed = Time.time;
            canJump = true;
            if (jumping == false)
            { 
                playermodel.GetComponent<Animator>().Play("Jump");
                jumping = true;
                Invoke("nojump", 1f);
                //Invoke("idleanimation", 2f);
            }

        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 15;
            playermodel.GetComponent<Animator>().Play("Run");
        }
        else
        {
            speed = 10;
        }
    }

    private void nojump ()
    {
        jumping = false;
    }
    private void norun()
    {
        running = false;
    }
    private void idleanimation()
    {
        playermodel.GetComponent<Animator>().Play("idle");
    }
}
