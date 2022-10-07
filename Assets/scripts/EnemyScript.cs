using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject Player;
    float x;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        x = Player.transform.position.x;
        y = Player.transform.position.y;

        int moveDirection = -1;

        
    }

    // Update is called once per frame
    void Update()
    {
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
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
        }
    }

     

}
