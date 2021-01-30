﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float speed;
    private int xspeed;
    private int yspeed;
    public Rigidbody2D rb;
    public Vector2 Vec;
    public Animator anim;
    public int lastmove;
    void Update()
    {
        Move();
    }


    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            xspeed = 1;
            lastmove = 1;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            lastmove = -1;
            xspeed = -1;
        }
        else
        {
            xspeed = 0;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            yspeed = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            yspeed = -1;
        }
        else
        {
            yspeed = 0;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.Q))
        {
            xspeed = 0;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Z))
        {
            yspeed = 0;
        }

        if(lastmove==-1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        Vec = new Vector2(xspeed * speed, yspeed * speed);

        if(Vec==new Vector2(0,0))
        {
            anim.SetBool("Running", false);
        }else
        {
            anim.SetBool("Running", true);
        }
        rb.velocity = Vec;

    }
}