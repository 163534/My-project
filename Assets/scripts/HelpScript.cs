using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
    public Player p;
    LayerMask groundLayerMask;
    public bool isGrounded;
    public Animator anim;

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
        
        anim = GetComponent<Animator>();
        
    }


    public void FlipObject (bool flip)
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }



    }

    public bool GetFlipDirection()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        return sr.flipX;
    }

    public void DoRayCollisionCheck()
    {
        float rayLength =0.15f;

                                                                                                                // cast a ray downward of length 1 \\
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;
        isGrounded = false;

        if ( hit.collider != null)
        {
            hitColor = Color.red;
            isGrounded = true;
        }
                                                                                                                       // draw a debug ray position \\
                                                                                                              // you need to enable gizmos in the editor to see these \\
         Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor); 
        
        if (isGrounded)
        {
           anim.SetBool("jump", false);
        }
        else
        {
           anim.SetBool("jump", true);
        }

    }
     



}

