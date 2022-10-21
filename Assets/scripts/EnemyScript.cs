using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    Rigidbody2D rb;
    int moveDirection;
    float rayLength;
    float moveSpeed;
    public GameObject bullet;
    // public GameObject Player;
    float x;
    float y;
    bool isPatrolling;

    // Start is called before the first frame update
    void Start()
    {
        //  x = Player.transform.position.x;
        //  y = Player.transform.position.y;

        rayLength = 0.5f;
        moveSpeed = 0.5f;
        moveDirection = 1;
        isPatrolling = true;
        rb = GetComponent<Rigidbody2D>();
        groundLayerMask = LayerMask.GetMask("Ground");


    }

    //Update is called once per frame
    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (isPatrolling)
        {
            RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, rayLength, groundLayerMask);
            RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, rayLength, groundLayerMask);

            Color hitColor = Color.white;
            Debug.DrawRay(transform.position, Vector2.left * rayLength, hitColor);
            Debug.DrawRay(transform.position, Vector2.right * rayLength, hitColor);

            rb.velocity = new Vector2(moveSpeed * moveDirection, transform.position.y);
            if (right.collider != null)
            {
                hitColor = Color.red;
                moveDirection = -1;
            }
            if (left.collider != null)
            {
                hitColor = Color.green;
                moveDirection = 1;
            }
        }
    }
}      


    
     


