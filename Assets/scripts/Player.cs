using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update\\
    public GameObject bullet;

    // makes code in the helper script useable \\
    HelpScript helper;
    Rigidbody2D rb;
    private Animator anim;
    public int speed;
    bool touchingPlatform;
    
    


    void Start()
    {
        // uses code from the helper script using "helper" \\
        helper = gameObject.AddComponent<HelpScript>();
        rb = GetComponent<Rigidbody2D>();

        speed = 1;

        //uses the Animator component as anim \\
        anim = GetComponent<Animator>();
        anim.SetBool("stand", false);
        anim.SetBool("walk", false);
        anim.SetBool("attack", false);

    }

    // Update is called once per frame\\
    void Update()
    {
        helper.DoRayCollisionCheck();
        ReadKeys();

        int moveDirection = 1;

       if (helper.GetFlipDirection())
        {
            moveDirection = -1;
        }

        
       // fires bullets \\

        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet at the position and roatation of the player \\
            GameObject clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);

            // get the rigidbody componet \\
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set velocity \\
            rb.velocity = new Vector3(10 * moveDirection, 0, 0);

            // set the position close to the player \\
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + 1);
        }
        
    }

    void ReadKeys()
    {
        

        //rb.velocity = new Vector2(0, 0);\\

        if (Input.GetKeyDown("up") && helper.isGrounded)
        {
            //print("player pressed up");
            //transform position = new Vector2(transform.position.x, transform.position.y + (speedTime.deltaTime) );
            rb.velocity = new Vector2(0, 4);
            
        }
      

        if (Input.GetKey("c"))
        {
           
            anim.SetBool("attack", true);
            
        }

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(2, 0);
            anim.SetBool("walk", true);
            helper.FlipObject(false);

            // gameObject.transform.localScale = new Vector3(1, 1, 1);
            
        }

        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-2, 0);
            anim.SetBool("walk", true);
            helper.FlipObject(true);

            // gameObject.transform.localScale=new Vector3(-1, 1, 1);
            

        }


        // check for idle
        if ((Input.GetKey("right") == false && Input.GetKey("left") == false))
        {
            anim.SetBool("walk", false);
            anim.SetBool("stand", true);
        }

        

    }

   


}



















