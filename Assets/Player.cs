using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update\\
    Rigidbody2D rb;
    private Animator anim;
    public int speed;
    bool touchingPlatform;
    bool isJumping;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        speed = 1;
        anim = GetComponent<Animator>();
        anim.SetBool("stand", false);
        anim.SetBool("walk", false);
        

    }

    // Update is called once per frame\\
    void Update()
    {
        ReadKeys();
        

        
    }

    void ReadKeys()
    {
        

        //rb.velocity = new Vector2(0, 0);\\

        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            //print("player pressed up");
            //transform position = new Vector2(transform.position.x, transform.position.y + (speedTime.deltaTime) );
            rb.velocity = new Vector2(0, 4);
            
            anim.SetBool("jump", true);
            
        }
        
         
        if (Input.GetKey("c"))
        {
           
            anim.SetBool("attack", true);
            
        }
       

        

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(2, 0);

            anim.SetBool("walk", true);
           
            
        }

        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-2, 0);

            anim.SetBool("walk", true);
            

        }


        // check for idle
        if ((Input.GetKey("right") == false && Input.GetKey("left") == false))
        {   

            anim.SetBool("stand", true);
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
            anim.SetBool("jump", false);
            
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
            anim.SetBool("walk", false);
        }
    }

}



















