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
    public int life;
    public List<GameObject> LifeList;
    public SoundManager Sound;
    public GameObject Fin;

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
        else if (Input.GetKey(KeyCode.A))
        {
            lastmove = -1;
            xspeed = -1;
        }
        else
        {
            xspeed = 0;
        }

        if (Input.GetKey(KeyCode.W))
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

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            xspeed = 0;
        }

        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
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

    void UpdateLife()
    {
        GameManager.Multi = 0;
        life -= 1;
        if(life>=0)
        {
        LifeList[life].SetActive(false);
        }else
        {
            Fin.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") && collision.GetComponent<BulletScript>().Friendly==false)
        {
            Sound.Play("Angry");
            UpdateLife();
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Drop"))
        {
            Sound.Play("Yessir");
            GameManager.Score += 1;
            Destroy(collision.gameObject);
           
        }
    }
}
