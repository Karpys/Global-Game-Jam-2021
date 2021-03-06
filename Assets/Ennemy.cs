﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    public ListTransform TransformManager;
    public GameObject Player;
    public GameObject Drop;
    public Vector2 PosToGo;
    public float speed;
    public int id;
    public List<int> ListId;
    public int life;
    public Color BaseColor;
    public Color HitColor;
    public float HitTime;
    public float HitTimeSet;
    void Start()
    {
        /*PosToGo = ListPat[index].transform.position;*/
        BaseColor = GetComponent<SpriteRenderer>().color;
        PosToGo = TransformManager.ListTrans[ListId[id]].transform.position;
        transform.position = PosToGo;
        HitTimeSet = HitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        transform.position = Vector2.MoveTowards(transform.position, PosToGo, speed * Time.deltaTime);
        Vector2 PosActor = new Vector2(transform.position.x, transform.position.y);

        if (PosActor == PosToGo)
        {
            FindNextPat();
        }

        if (life <= 0)
        {
            int multi = GameManager.Multi;
            if (GameManager.Multi >= 4)
            {
                multi = 4;
            }
            int rdm = Random.Range(1, 10);
            if (multi + 1 >= rdm)
            {
                GameObject dro = Instantiate(Drop, transform.position, transform.rotation);
                dro.GetComponent<Drop>().Player = Player;
                
            }
            Debug.Log((multi + 1) + " " + rdm);
            GameManager.EnnemyCount += 1;
            GameManager.Multi += 1;
            
            
            Destroy(gameObject);
        }

        if (HitTime > 0)
        {

            HitTime -= Time.deltaTime;
            if (HitTime <= 0)
            {
                GetComponent<SpriteRenderer>().color = BaseColor;
            }
        }
    }

    public void FindNextPat()
    {
        id += 1;
        if (ListId.Count == id)
        {
            id = 2;
        }

        PosToGo = TransformManager.ListTrans[ListId[id]].transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (collision.GetComponent<BulletScript>().Friendly == true)
            {
                life -= 1;
                Instantiate(collision.GetComponent<BulletScript>().OnDestroy, transform.position, transform.rotation);
                Destroy(collision.gameObject);
                HitTime = HitTimeSet;
                GetComponent<SpriteRenderer>().color = HitColor;
                

            }
        }
    }
}
