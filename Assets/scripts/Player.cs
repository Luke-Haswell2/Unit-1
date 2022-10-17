using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    bool touchingPlatform;
    public GameObject Bullet;
    SpriteRenderer sr;
    HelperScript helper;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            helper.FlipObject(true);
        }
        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            rb.velocity = new Vector2(0, 8);
            
        }

        int moveDirection = 1;
        if (Input.GetKeyDown("down"))
        {
            
            GameObject clone;
            clone = Instantiate(Bullet, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 0, transform.position.z);

            
            
        }
        
    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
        }
    }
}
