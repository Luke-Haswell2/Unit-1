using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject end;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = end.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // create radio and make script delete player when they collect radio and spawn end of game text
        

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            sr.enabled = true;
        }
    }
}
