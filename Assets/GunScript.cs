using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject SocketRight;
    public GameObject SocketLeft;
    public GameObject Bullet;
    public float Cd;
    public float CdSet;
    public Vector3 mousePos;
    void Start()
    {
        CdSet = Cd;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        AdjustPosition();
        FaceMouse();

        if(Input.GetMouseButton(0) && Cd<=0)
        {
            Cd = CdSet;
            Instantiate(Bullet, transform.position, transform.rotation);
        }

        if(Cd>0)
        {
            Cd -= Time.deltaTime;
        }
       
    }

    public void AdjustPosition()
    {
        if (Player.GetComponent<SpriteRenderer>().flipX == true)
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
