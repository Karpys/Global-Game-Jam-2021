using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Actor;
    public GameObject SocketRight;
    public GameObject SocketLeft;
    public GameObject Bullet;
    public GameObject Target;
    public float Cd;
    public float CdSet;
    public Vector3 mousePos;
    public bool Friendly;
    void Start()
    {
        CdSet = Cd;
        if(!Friendly)
        {
            Target = Actor.GetComponent<Ennemy>().Player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Friendly)
        {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
       
        }else
        {
            mousePos = Target.transform.position;
            mousePos.z = 0;
        }
        FaceMouse();
        AdjustPosition();
        
        if(Friendly)
        {

        if(Input.GetMouseButton(0) && Cd<=0)
        {
            Cd = CdSet;
            GameObject Tir = Instantiate(Bullet, transform.position, transform.rotation);
            Tir.GetComponent<BulletScript>().Friendly = Friendly;
        }

        }else
        {
            if(Cd<=0)
            {
                GameObject TirEn = Instantiate(Bullet, transform.position, transform.rotation);
                TirEn.GetComponent<BulletScript>().Friendly = Friendly;
                Cd = CdSet;
            }
        }
        if(Cd>0)
        {
            Cd -= Time.deltaTime;
        }
       
    }

    public void AdjustPosition()
    {
        if (Actor.GetComponent<SpriteRenderer>().flipX == true)
        {
            transform.position = SocketLeft.transform.position;
           
            /* GetComponent<SpriteRenderer>().flipX = true;*/
        }
        else
        {
           /* GetComponent<SpriteRenderer>().flipX = false;*/
            transform.position = SocketRight.transform.position;
        }

        if (mousePos.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = true;
        }
    }

    public void FaceMouse()
    {
        
        Vector3 Angle = transform.position - mousePos;
        float angle = Mathf.Atan2(Angle.y, Angle.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
