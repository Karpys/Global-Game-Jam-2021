using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiScript : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Text;
    public Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text.text = ("x" + GameManager.Multi);
        if(GameManager.Multi>=4)
        {
            anim.SetBool("Agite", true);
        }
        else
        {
            anim.SetBool("Agite", false);
        }
    }
}
