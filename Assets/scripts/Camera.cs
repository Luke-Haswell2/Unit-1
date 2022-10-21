using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform Player;
    Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
       if (Player.transform.position.x > transform.position.x-4)
        {
            rb.velocity = new Vector2(2.5f, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        
        if (Player.transform.position.x < transform.position.x - 4.1)
        {
            rb.velocity = new Vector2(-2.5f, 0);
        }
    }
}
