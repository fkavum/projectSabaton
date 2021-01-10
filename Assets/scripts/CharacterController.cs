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

    public float speed = 7.0f;
    private float translation;
    private float straffe;
    public int forceConst = 10;
    private bool canJump;
    private Rigidbody selfRigidbody;
    private float timepassed;
    private float jumpcooldown = 1.5f;
    private float crouchwalkcooldown;
    private float crouchtimepassed;
    private float walktimepassed;
    private float walkanimationcooldown;
    public float camerasmooth = 0.125f; 
    public GameObject playermodel;
    private bool idle;
    private bool jumping;
    private bool running;
    private bool crouching;
    private Vector3 lastposition;
    public Transform characterhead;
    public Transform camera;
    private Vector3 velocity = Vector3.zero;


    void LateUpdate()
    {
        
        camera.position = Vector3.SmoothDamp(camera.position, characterhead.position, ref velocity, camerasmooth);
    }
    // Use this for initialization
    void Start()
    {
        
        crouchwalkcooldown = 1.1f;
        crouchwalkcooldown = 0.67f;
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
        if ((Input.GetKey(KeyCode.W) && (jumping ==false )&&(running == false)&&(crouching==false)&&(Time.time - walktimepassed > walkanimationcooldown)))
        {
            walktimepassed = Time.time;
            playermodel.GetComponent<Animator>().Play("Run");
            running = true;
            //Invoke("norun", 0.67f);

            //Invoke("noanimation(running)", 1.5f);
        }
        else if (Input.GetKeyUp(KeyCode.W)&& crouching ==false&&jumping==false)
        {
            //playermodel.GetComponent<Animator>().SetBool("Run", false);
            running = false;
            playermodel.GetComponent<Animator>().Play("Run_idle");
            //Invoke("idleanimation", 0.2f);
            //playermodel.GetComponent<Animator>().Play("idle");
        }
        if ((Input.GetKey(KeyCode.S) && (jumping == false) && (running == false) && (crouching == false) && (Time.time - walktimepassed > walkanimationcooldown)))
        {
            walktimepassed = Time.time;
            playermodel.GetComponent<Animator>().Play("Reverse_walk");
            running = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.S) && crouching == false && jumping == false)
        {
            
            running = false;
            playermodel.GetComponent<Animator>().Play("Run_idle");
            
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
            if (jumping == false &&(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
            {
                playermodel.GetComponent<Animator>().Play("JumpWhileRun");
                jumping = true;
                Invoke("nojump", 1f);
                
                //Invoke("idleanimation", 2f);
            }
            else if (jumping == false)
            { 
                playermodel.GetComponent<Animator>().Play("Jump");
                jumping = true;
                Invoke("nojump", 1f);
                if (Input.GetKey(KeyCode.W))
                {
                    
                    
                    //Invoke("idleanimation", 2f);
                }
                //Invoke("idleanimation", 2f);
            }
            
        }
        if (crouching == false) { 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 12;
            playermodel.GetComponent<Animator>().Play("Run_fast");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKeyUp(KeyCode.W)))
        {
            playermodel.GetComponent<Animator>().Play("Run_idle");
            speed = 7;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
        {
            playermodel.GetComponent<Animator>().Play("Run_fast_slow");
            speed = 7;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) && (Input.GetKey(KeyCode.S)))
        {
            playermodel.GetComponent<Animator>().Play("Run_fast_slow_reverse");
            speed = 7;
        }
        }
        if (Input.GetKeyDown(KeyCode.C)&& crouching==false )
        {
            speed /=  2;
            playermodel.GetComponent<Animator>().Play("Stand_crouch");
            crouching = true;
        }
        else if (Input.GetKeyDown(KeyCode.C) && crouching == true)
        {
            speed = 7;
            playermodel.GetComponent<Animator>().Play("Crouch_stand");
            crouching = false;

        }

        if ((Input.GetKey(KeyCode.W)&&(crouching==true)&&(Time.time - crouchtimepassed > crouchwalkcooldown)))
        {
            crouchtimepassed = Time.time;
            playermodel.GetComponent<Animator>().Play("Crouch_walk");
            
        }
        else if ((Input.GetKeyUp(KeyCode.W) && (crouching == true)))
        {
            playermodel.GetComponent<Animator>().Play("Crouch_walk_pose");
            //Invoke("crouchidleanimation", 0.35f);

        }
        if ((Input.GetKey(KeyCode.S) && (crouching == true) && (Time.time - crouchtimepassed > crouchwalkcooldown)))
        {
            crouchtimepassed = Time.time;
            playermodel.GetComponent<Animator>().Play("Reverse_crouchwalk");

        }
        else if ((Input.GetKeyUp(KeyCode.S) && (crouching == true)))
        {
            playermodel.GetComponent<Animator>().Play("Crouch_walk_pose");
            //Invoke("crouchidleanimation", 0.35f);

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
    private void crouchidleanimation()
    {
        playermodel.GetComponent<Animator>().Play("Crouch_pose");
    }

}
