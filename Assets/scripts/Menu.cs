using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    SpriteRenderer sr1;
    SpriteRenderer sr2;
    SpriteRenderer sr3;
    public GameObject m1;
    public GameObject m2;
    public GameObject m3;

    // Start is called before the first frame update
    void Start()
    {
        sr1 = m1.GetComponent<SpriteRenderer>();
        sr2 = m2.GetComponent<SpriteRenderer>();
        sr3 = m3.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //put in bunker (push v for help)
        //v = main menu
        //c = controls
        //b = back story
        //x = start
        if (Input.GetKeyDown("v"))
        {
            sr1.enabled = true;
        }
        if (Input.GetKeyDown("b"))
        {
            sr1.enabled = false;
            sr2.enabled = true;
        }
        if (Input.GetKeyDown("c"))
        {
            sr2.enabled = false;
            sr3.enabled = true;
        }
        if (Input.GetKeyDown("x"))
        {
            sr3.enabled = false;
        }
    }
}
