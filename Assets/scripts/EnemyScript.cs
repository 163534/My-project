using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    int moveDirection;
    public GameObject bullet;
    public GameObject Player;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        x = Player.transform.position.x;
        y = Player.transform.position.y;

        rb = GetComponent<Rigidbody2D>();
        


    }

    /* Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    { 
      int moveDirection = -1;

      rb.velocity = new Vector2(10 * moveDirection, gameObject.transform.position.y);


    }
     */

}
