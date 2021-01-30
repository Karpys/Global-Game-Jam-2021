using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Ennemy;
    public GameObject Player;
    public ListTransform Trans;
    public GameObject EnnemyBoat;
    public float CdSpawn;
    public float CdSpawnSet;
    public int NbrEnnemy;
    /*public List<int> ListIdProvi;*/
    void Start()
    {
        CdSpawnSet = CdSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (CdSpawn<=0)
        {
            int rdm = Random.Range(1, 4);
            CdSpawn = CdSpawnSet/rdm;
            NbrEnnemy -= 1;
            rdm = Random.Range(1, 100);
            if (rdm>30)
            {
            GameObject En = Instantiate(Ennemy, transform.position, transform.rotation);
            En.GetComponent<Ennemy>().TransformManager = Trans;
            En.GetComponent<Ennemy>().Player = Player;
            
            List<int> ListProvi = new List<int>();
            rdm = Random.Range(1, 5);
            if(rdm==1)
            {
                ListProvi.Add(24);
                ListProvi.Add(0);
            }else if(rdm==2)
            {
                ListProvi.Add(25);
                ListProvi.Add(7);
            }
            else if (rdm == 3)
            {
                ListProvi.Add(26);
                ListProvi.Add(16);
            }
            else if (rdm == 4)
            {
                ListProvi.Add(27);
                ListProvi.Add(23);
            }

            rdm = Random.Range(1, 6);

            if (rdm == 1)
            {
                ListProvi.AddRange(new List<int>() { 0, 7, 23, 16 });
            }
            else if (rdm == 2)
            {
                ListProvi.AddRange(new List<int>() { 16, 0, 7, 0});
            }
            else if (rdm == 3)
            {
                ListProvi.AddRange(new List<int>() {7,23,16,23});
            }
            else if (rdm == 4)
            {
                ListProvi.AddRange(new List<int>() {8,4,15,20});
            }
            else if (rdm == 5)
            {
                ListProvi.AddRange(new List<int>() { 0, 23, 7, 16 });
            }
            En.GetComponent<Ennemy>().ListId = ListProvi;
            }else if(rdm <=30)
            {
                GameObject En = Instantiate(EnnemyBoat, transform.position, transform.rotation);
                En.GetComponent<Ennemy>().TransformManager = Trans;
                En.GetComponent<Ennemy>().Player = Player;
                List<int> ListProvi = new List<int>();
                ListProvi.AddRange(new List<int>() { 28, 29, 30, 31 });
                En.GetComponent<Ennemy>().ListId = ListProvi;

        }
        }
        if(CdSpawn>0)
        {
            CdSpawn -= Time.deltaTime;
        }
    }
}
