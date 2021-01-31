using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int EnnemyCount;
    public static int Multi;
    public static int Score;
    public TextMeshProUGUI Scor;
    public TextMeshProUGUI Kill;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scor.text = Score.ToString();
        Kill.text = EnnemyCount.ToString();
    }
}
