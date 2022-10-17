using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
        }
        
        if (Player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(1, rb.velocity.y);
        }
    }
}
