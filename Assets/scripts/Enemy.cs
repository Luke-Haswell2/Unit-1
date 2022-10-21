using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    Rigidbody2D rb;
    HelperScript helper;
    private Animator anim;
    SpriteRenderer sr;
    public float deathDisplayTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        helper = gameObject.AddComponent<HelperScript>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        deathDisplayTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);

        if ((Player.transform.position.x < transform.position.x) && (transform.position.x-5 <= Player.transform.position.x))
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
            anim.SetBool("walk", true);
            helper.FlipObject(true);
        }
        
        if (Player.transform.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(1, rb.velocity.y);
            helper.FlipObject(false);
            anim.SetBool("walk", true);
        }

       CheckForEnemyDead();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sr.color = Color.red;
            deathDisplayTime = 0.5f;
            print("dead");
        }
      
       
    }


    void CheckForEnemyDead()
    {

        if (deathDisplayTime != 0)
        {
            deathDisplayTime -= Time.deltaTime;
            if (deathDisplayTime < 0)
            {
                Destroy(gameObject);
            }

        }
    }

}
