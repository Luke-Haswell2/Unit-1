using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    bool touchingPlatform;
    public GameObject Bullet;
    SpriteRenderer sr;
    SpriteRenderer gun_sr;
    HelperScript helper;
    private Animator anim;
    bool isJumping;
    public GameObject gun;

    public float gunDisplayTime;
    public float playerDisplayTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        gun_sr = gun.GetComponent<SpriteRenderer>();

        helper = gameObject.AddComponent<HelperScript>();
        anim = GetComponent<Animator>();
        isJumping = false;
        playerDisplayTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false );
        anim.SetBool("jump", false);

        if (Input.GetKey("right"))
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            anim.SetBool("walk", true);
            helper.FlipObject(false);
        }
        if (Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-3, rb.velocity.y);
            helper.FlipObject(true);
            anim.SetBool("walk", true);
        }
        if (Input.GetKeyDown("up") && touchingPlatform)
        {
            rb.velocity = new Vector2(0, 8);
            isJumping = true;
        }
         if( (isJumping == true) )
        {
            anim.SetBool("jump", true);
            if ((touchingPlatform == true) && rb.velocity.y <1)
            {
                isJumping = false;
            }
        }

        int moveDirection = 1;
        if (Input.GetKeyDown("down"))
        {
            
            GameObject clone;
            clone = Instantiate(Bullet, transform.position, transform.rotation);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            rb.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 0.6f, transform.position.z);

            gun_sr.enabled = true;
            gunDisplayTime = 0.7f;
        }

        if( gunDisplayTime > 0)
        {
            gunDisplayTime -= Time.deltaTime;
        }
        else
        {
            gun_sr.enabled = false;
        }
        CheckForPlayerDead();
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
            sr.color = Color.red;
            playerDisplayTime = 0.5f;
            print("dead");
        }


    }


    void CheckForPlayerDead()
    {

        if (playerDisplayTime != 0)
        {
            playerDisplayTime -= Time.deltaTime;
            if (playerDisplayTime < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}

