using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScript : MonoBehaviour
{
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
}
