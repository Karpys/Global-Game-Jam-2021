using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Rigidbody2D rb;
    public float LifeTime;
    
    void Start()
    {
    }


    void Update()
    {
        LifeTime -= Time.deltaTime;

        if(LifeTime<=0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = -transform.right * speed;
    }
}
