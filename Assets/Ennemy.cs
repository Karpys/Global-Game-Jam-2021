using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    public ListTransform TransformManager;
    public Vector2 PosToGo;
    public float speed;
    public int id;
    public List<int> ListId;
    void Start()
    {
        /*PosToGo = ListPat[index].transform.position;*/

        PosToGo = TransformManager.ListTrans[ListId[id]].transform.position;
        transform.position = PosToGo;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PosToGo,speed);
        Vector2 PosActor = new Vector2(transform.position.x, transform.position.y);

        if(PosActor==PosToGo)
        {
            FindNextPat();
        }

    }

    public void FindNextPat()
    {
        id += 1;
        if(ListId.Count==id)
        {
            id = 2;
        }

        PosToGo = TransformManager.ListTrans[ListId[id]].transform.position;
    }
}
