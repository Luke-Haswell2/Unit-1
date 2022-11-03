using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heli : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >=83)
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);

        }
    }
}
